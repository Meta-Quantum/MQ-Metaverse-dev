using UnityEngine;
using UnityEngine.UI;

public class ArcadeQuitButton : MonoBehaviour
{
    private Button _button;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(QuitArcade);
    }
    
    private void QuitArcade()
    {
        ArcadeManager.Instance.ExitArcade();
    }
}
