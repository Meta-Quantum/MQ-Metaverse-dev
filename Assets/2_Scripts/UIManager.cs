using Plugins.CustomScripts;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public GameObject globalCanvas;
    public GameObject arcadeCanvas;
    public GameObject paintingCanvas;
    public GameObject buildingCanvas;
    public GameObject barCodeCanvas;
    public GameObject storeFrontCanvas;
    
    public CanvasHitDetector globalCanvasHitDetector;
    public CanvasHitDetector arcadeCanvasHitDetector;
    public CanvasHitDetector paintingCanvasHitDetector;
    public CanvasHitDetector buildingCanvasHitDetector;
    public CanvasHitDetector barCodeCanvasHitDetector;
    public CanvasHitDetector storeFrontCanvasHitDetector;
    

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
        
        barCodeCanvas.SetActive(false);
        barCodeCanvasHitDetector = barCodeCanvas.GetComponent<CanvasHitDetector>();
        
        storeFrontCanvas.SetActive(false);
        storeFrontCanvasHitDetector = storeFrontCanvas.GetComponent<CanvasHitDetector>();
    }
    
    public void EnterArcade()
    {
        globalCanvas.SetActive(false);
        arcadeCanvas.SetActive(true);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }

    public void ExitArcade()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }
    
    public void EnterPainting()
    {
        globalCanvas.SetActive(false);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(true);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }
    
    public void ExitPainting()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }
    
    public void EnterBuildingMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(true);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }
    
    public void ExitBuildingMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }
    
    public void EnterPassCodeMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(true);
        storeFrontCanvas.SetActive(false);
    }
    
    public void ExitPassCodeMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
    }
    
    public void EnterStoreFrontMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(true);
    }
    
    public void ExitStoreFrontMode()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
        barCodeCanvas.SetActive(false);
        storeFrontCanvas.SetActive(false);
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
        else if(arcadeCanvas.activeSelf)
        {
            if (arcadeCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        else if (paintingCanvas.activeSelf)
        {
            if (paintingCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        else if (buildingCanvas.activeSelf)
        {
            if (buildingCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        else if (barCodeCanvas.activeSelf)
        {
            if (barCodeCanvasHitDetector.IsPointerOverUI())
            {
                result = true;
            }
        }
        
        return result;
    }
}
