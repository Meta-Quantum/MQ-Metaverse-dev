using System.Collections;
using System.Collections.Generic;
using Com.MyCompany.MyGame;
using UnityEngine;
using UnityEngine.UI;

public class ClosePassCodeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
	
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }
	
    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }
	
    private void OnButtonClicked()
    {
        UIManager.Instance.ExitPassCodeMode();
        GameManager.Instance.ExitMouseUIMode();
    }
}
