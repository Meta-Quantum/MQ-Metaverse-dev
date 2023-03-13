using Com.MyCompany.MyGame;
using GameCreator.Runtime.Characters;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private GameObject thirdPersonCameraPrefab;
    [SerializeField]
    private GameObject _mannequin;
    private MousePainter _mousePainter;
    private Camera _camera;
    private Character _character;
    
    private bool _inArcade = false;
    private bool _inPainting = false;

    private void Start()
    {
        GameManager.Instance.localPlayerController = this;
        //Cache Components
        _mousePainter = GetComponent<MousePainter>();
        _character = GetComponent<Character>();
        
        //Set tag to Player
        gameObject.tag = "Player";
        
        //Instantiate the third person camera
        var transform1 = transform;
        var instantiatedCamera = Instantiate(thirdPersonCameraPrefab, transform1.position, transform1.rotation);
        _camera = instantiatedCamera.GetComponent<ThirdPersonCamera>().GetCamera();
        
        _mousePainter.cam = _camera;
        _mousePainter.isActive = false;
    }
    
    public void GetInArcade(bool inArcade)
    {
        if (inArcade)
        {
            EnterArcade();
        }
        else
        {
            ExitArcade();
        }
    }
    
    public void GetInPainting(bool inPainting)
    {
        if (inPainting)
        {
            EnterPainting();
        }
        else
        {
            ExitPainting();
        }
    }

    private void ExitArcade()
    {
        _inArcade = false;
        _mousePainter.isActive = false;
        _character.enabled = true;
        _camera.enabled = true;
        _mannequin.SetActive(true);
    }

    private void EnterArcade()
    {
        _inArcade = true;
        _mousePainter.isActive = false;
        _character.enabled = false;
        _camera.enabled = false;
        _mannequin.SetActive(false);
    } 
    
    private void ExitPainting()
    {
        _inPainting = false;
        _mousePainter.isActive = false;
        _character.enabled = true;
        _camera.enabled = true;
        _mannequin.SetActive(true);
    }

    private void EnterPainting()
    {
        _inPainting = true;
        _mousePainter.isActive = true;
        _character.enabled = false;
        _camera.enabled = false;
        _mannequin.SetActive(false);
    } 
}
