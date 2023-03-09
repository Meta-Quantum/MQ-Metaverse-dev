using UnityEngine;

public class CursorController : MonoBehaviour
{
    bool isVisible = true;
    
    
    private void SwitchCursorVisible() {
        Cursor.visible = !isVisible;
        isVisible = !isVisible;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            SwitchCursorVisible();
        }
    }
}
