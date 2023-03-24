using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPaintButton : MonoBehaviour
{
    private Button button;
    public Color Color;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { PaintManager.Instance.SetCurrentUsedColour(Color); });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
