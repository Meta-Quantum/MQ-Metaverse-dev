using System;
using Com.MyCompany.MyGame;
using UnityEngine;

public class ArcadeManager : MonoBehaviour, Interactable
{
    static public ArcadeManager Instance;
    
    [SerializeField]
    private EmulatorManager _emulatorManager;
    
    private bool isInTrigger;

    private void Start()
    {
        Instance = this;
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

    private void Update()
    {
        //if its in the trigger and the player presses the interact button
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ArcadeManager - Interacting");
            Interact();
        }
    }

    public void Interact()
    {
        EnterArcade();
    }
    
    public void EnterArcade()
    {
        GameManager.Instance.EnterArcade();
        UIManager.Instance.EnterArcade();
        _emulatorManager.StartArcade();
    }
    
    public void ExitArcade()
    {
        GameManager.Instance.ExitArcade();
        UIManager.Instance.ExitArcade();
        _emulatorManager.StopArcade();
    }
}
