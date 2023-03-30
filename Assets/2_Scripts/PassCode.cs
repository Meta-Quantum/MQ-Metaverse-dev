using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PassCode : MonoBehaviour
{

    [SerializeField] private PassCodeUI passCodeUI;
    
    private bool _isInTrigger;

    private void Awake()
    {
        passCodeUI.gameObject.SetActive(false);
        passCodeUI.OnButtonClickedEvent += OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        passCodeUI.gameObject.SetActive(false);
        var passcode = passCodeUI.GetPasscode();
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
        passCodeUI.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        //if its in the trigger and the player presses the interact button
        if (_isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            passCodeUI.gameObject.SetActive(true);
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
