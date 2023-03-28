using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarCode : MonoBehaviour
{

    [SerializeField] private BarCodeUI _barCodeUI;
    
    private bool _isInTrigger;

    private void Awake()
    {
        _barCodeUI.gameObject.SetActive(false);
        _barCodeUI.OnButtonClickedEvent += OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        _barCodeUI.gameObject.SetActive(false);
        var passcode = _barCodeUI.GetPasscode();
        Debug.Log(passcode);

        if (passcode == "1234")
        {
            SceneManager.LoadScene(passcode);
        }
        else
        {
            Debug.Log("Wrong passcode");
        }
    }

    private void Start()
    {
        _barCodeUI.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        //if its in the trigger and the player presses the interact button
        if (_isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            _barCodeUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isInTrigger = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isInTrigger = false;
        }
    }
}
