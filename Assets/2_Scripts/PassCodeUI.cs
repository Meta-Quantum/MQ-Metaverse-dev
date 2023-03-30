using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class PassCodeUI : MonoBehaviour
{
    public event Action OnButtonClickedEvent;
    
    [SerializeField] private TMP_InputField _tmpInputField;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }
    
    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }
    
    private void OnButtonClicked()
    {
        OnButtonClickedEvent?.Invoke();
    }

    public string GetPasscode()
    {
        return  _tmpInputField.text;
    }
}
