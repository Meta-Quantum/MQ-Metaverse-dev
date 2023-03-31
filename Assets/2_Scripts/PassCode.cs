using Com.MyCompany.MyGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PassCode : MonoBehaviour
{

    [SerializeField] private PassCodeUI passCodeUI;
    
    private bool _isInTrigger;

    private void Awake()
    {
        passCodeUI.OnButtonClickedEvent += OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        UIManager.Instance.ExitBarCodeMode();
        GameManager.Instance.ExitMouseUIMode();
        
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
        if (_isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.EnterBarCodeMode();
            GameManager.Instance.EnterMouseUIMode();
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
