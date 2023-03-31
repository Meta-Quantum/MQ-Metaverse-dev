using Plugins.CustomScripts;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public GameObject globalCanvas;
    public GameObject arcadeCanvas;
    public GameObject paintingCanvas;
    public GameObject buildingCanvas;
    
    public CanvasHitDetector globalCanvasHitDetector;
    public CanvasHitDetector arcadeCanvasHitDetector;
    public CanvasHitDetector paintingCanvasHitDetector;
    public CanvasHitDetector buildingCanvasHitDetector;
    

    public void Awake()
    {
        Instance = this;
        globalCanvas.SetActive(true);
        globalCanvasHitDetector = globalCanvas.GetComponent<CanvasHitDetector>();
        
        arcadeCanvas.SetActive(false);
        arcadeCanvasHitDetector = arcadeCanvas.GetComponent<CanvasHitDetector>();
        
        paintingCanvas.SetActive(false);
        paintingCanvasHitDetector = paintingCanvas.GetComponent<CanvasHitDetector>();
        
        buildingCanvas.SetActive(false);
        buildingCanvasHitDetector = buildingCanvas.GetComponent<CanvasHitDetector>();
    }
    
    public void EnterArcade()
    {
        globalCanvas.SetActive(false);
        arcadeCanvas.SetActive(true);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
    }
    
    public void ExitArcade()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
    }
    
    public void EnterPainting()
    {
        globalCanvas.SetActive(false);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(true);
        buildingCanvas.SetActive(false);
    }
    
    public void ExitPainting()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
    }
    
    public void EnterBuildingMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(true);
    }
    
    public void ExitBuildingMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
    }

    public bool IsPointerOverUI()
    {
        var result = false;

        if (globalCanvas.activeSelf)
        {
            if (globalCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        if(arcadeCanvas.activeSelf)
        {
            if (arcadeCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        if (paintingCanvas.activeSelf)
        {
            if (paintingCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        if (buildingCanvas.activeSelf)
        {
            if (buildingCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        
        return result;
    }
}
