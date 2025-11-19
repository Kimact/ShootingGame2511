using UnityEngine;

public class Input_KeyBoard : MonoBehaviour , IInputHandler
{
   public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
