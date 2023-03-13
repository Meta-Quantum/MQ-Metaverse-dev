using System;
using Com.MyCompany.MyGame;
using UnityEngine;

public class ArcadeManager : MonoBehaviour, Interactable
{
    [SerializeField]
    private EmulatorManager _emulatorManager;
    
    private bool isInTrigger;

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
            Debug.Log("Interacting");
            Interact();
        }
    }

    public void Interact()
    {
        //switch camera view to arcade view
        GameManager.Instance.localPlayerController.GetInArcade(true);
        _emulatorManager.StartArcade();
        //switch player controls to arcade controls
        
        
    }
}
