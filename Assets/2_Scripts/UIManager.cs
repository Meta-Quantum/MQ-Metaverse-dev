using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public GameObject globalCanvas;
    public GameObject arcadeCanvas;
    public GameObject paintingCanvas;

    public void Awake()
    {
        Instance = this;
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
    }
    
    public void EnterArcade()
    {
        globalCanvas.SetActive(false);
        arcadeCanvas.SetActive(true);
        paintingCanvas.SetActive(false);
    }
    
    public void ExitArcade()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
    }
    
    public void EnterPainting()
    {
        globalCanvas.SetActive(false);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(true);
    }
    
    public void ExitPainting()
    {
        globalCanvas.SetActive(true);
        arcadeCanvas.SetActive(false);
        paintingCanvas.SetActive(false);
    }
}
