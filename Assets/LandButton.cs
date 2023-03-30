using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LandButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _landPriceText;
    private Land _land;
    
    public void Initialize(Land land)
    {
        _land = land;
        _landPriceText.text = _land.price.ToString();
        
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
    
    private void OnClick()
    {
        Debug.Log($"You bought a {_land.landSize} land for {_land.price}!");
        SceneManager.LoadScene(_land.landSize + " Land");
    }
}
