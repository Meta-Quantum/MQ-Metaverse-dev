using UnityEngine;

public class CursorController : MonoBehaviour
{
    
    private void SwitchCursorVisible()
    {
        Cursor.visible = !Cursor.visible;
    }

    private void Update()
    {
       /* if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            SwitchCursorVisible();
        }*/
    }
}
