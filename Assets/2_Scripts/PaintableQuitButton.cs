using UnityEngine;
using UnityEngine.UI;

public class PaintableQuitButton : MonoBehaviour
{
	private Button _button;
    
	private void Start()
	{
		_button = GetComponent<Button>();
		_button.onClick.AddListener(QuitPainting);
	}
    
	private void QuitPainting()
	{
		PaintManager.Instance.ExitPainting();
	}
}