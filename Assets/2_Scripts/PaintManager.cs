using Com.MyCompany.MyGame;
using UnityEngine;
using UnityEngine.Rendering;

public class PaintManager : MonoBehaviour , Interactable {
    
    static public PaintManager Instance;

    private Color PaintColour = Color.red;

    public Shader texturePaint;
    public Shader extendIslands;
    [SerializeField]
    private Camera _camera;
    private GameObject _cameraGameObject;
    [SerializeField]
    private MousePainter _mousePainter;
    
    private bool isInTrigger;

    int prepareUVID = Shader.PropertyToID("_PrepareUV");
    int positionID = Shader.PropertyToID("_PainterPosition");
    int hardnessID = Shader.PropertyToID("_Hardness");
    int strengthID = Shader.PropertyToID("_Strength");
    int radiusID = Shader.PropertyToID("_Radius");
    int blendOpID = Shader.PropertyToID("_BlendOp");
    int colorID = Shader.PropertyToID("_PainterColor");
    int textureID = Shader.PropertyToID("_MainTex");
    int uvOffsetID = Shader.PropertyToID("_OffsetUV");
    int uvIslandsID = Shader.PropertyToID("_UVIslands");

    Material paintMaterial;
    Material extendMaterial;

    CommandBuffer command;

    public void Awake(){
        Instance = this;
        paintMaterial = new Material(texturePaint);
        extendMaterial = new Material(extendIslands);
        command = new CommandBuffer();
        command.name = "CommmandBuffer - " + gameObject.name;
        _mousePainter.enabled = false;
        _cameraGameObject = _camera.gameObject;
        _cameraGameObject.SetActive(false);
    }

    public void SetCurrentUsedColour(Color newColour)
    {
        PaintColour = newColour;
    }

    public void initTextures(Paintable paintable){
        RenderTexture mask = paintable.getMask();
        RenderTexture uvIslands = paintable.getUVIslands();
        RenderTexture extend = paintable.getExtend();
        RenderTexture support = paintable.getSupport();
        Renderer rend = paintable.getRenderer();

        command.SetRenderTarget(mask);
        command.SetRenderTarget(extend);
        command.SetRenderTarget(support);

        paintMaterial.SetFloat(prepareUVID, 1);
        command.SetRenderTarget(uvIslands);
        command.DrawRenderer(rend, paintMaterial, 0);

        Graphics.ExecuteCommandBuffer(command);
        command.Clear();
    }

    //Removed the color parameter from the paint method
    public void paint(Paintable paintable, Vector3 pos, float radius = 1f, float hardness = .5f, float strength = .5f){
        RenderTexture mask = paintable.getMask();
        RenderTexture uvIslands = paintable.getUVIslands();
        RenderTexture extend = paintable.getExtend();
        RenderTexture support = paintable.getSupport();
        Renderer rend = paintable.getRenderer();
        
        Debug.Log("PaintManager - getters");

        paintMaterial.SetFloat(prepareUVID, 0);
        paintMaterial.SetVector(positionID, pos);
        paintMaterial.SetFloat(hardnessID, hardness);
        paintMaterial.SetFloat(strengthID, strength);
        paintMaterial.SetFloat(radiusID, radius);
        paintMaterial.SetTexture(textureID, support);
        paintMaterial.SetColor(colorID, PaintColour);
        extendMaterial.SetFloat(uvOffsetID, paintable.extendsIslandOffset);
        extendMaterial.SetTexture(uvIslandsID, uvIslands);
        
        Debug.Log("PaintManager - setters");

        command.SetRenderTarget(mask);
        command.DrawRenderer(rend, paintMaterial, 0);

        command.SetRenderTarget(support);
        command.Blit(mask, support);

        command.SetRenderTarget(extend);
        command.Blit(mask, extend, extendMaterial);

        Graphics.ExecuteCommandBuffer(command);
        command.Clear();
    }
    
    private void Update()
    {
        //if its in the trigger and the player presses the interact button
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("PaintManager - Interacting");
            Interact();
        }
    }
    
    //On trigger enter with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }

    public void Interact()
    {
        EnterPainting();
    }
    
    public void EnterPainting()
    {
        GameManager.Instance.EnterPainting();
        UIManager.Instance.EnterPainting();
        _cameraGameObject.SetActive(true);
        _mousePainter.enabled = true;
        //unlock mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void ExitPainting()
    {
        GameManager.Instance.ExitPainting();
        UIManager.Instance.ExitPainting();
        _cameraGameObject.SetActive(false);
        _mousePainter.enabled = false;
    }
}