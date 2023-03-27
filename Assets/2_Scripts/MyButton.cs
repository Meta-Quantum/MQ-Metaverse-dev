using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textMeshPro;
    [SerializeField]
    private Button button;
    
    public void SetText(string text)
    {
        textMeshPro.text = text;
    }
    
    public void AddListener(Action action)
    {
        button.onClick.AddListener(() => action());
    }
    
    public void RemoveListener(Action action)
    {
        button.onClick.RemoveListener(() => action());
    } 
}
