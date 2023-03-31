using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public GameObject globalCanvas;
    public GameObject arcadeCanvas;
    public GameObject paintingCanvas;
    public GameObject buildingCanvas;

    public void Awake()
    {
        Instance = this;
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
        buildingCanvas.SetActive(false);
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
}
