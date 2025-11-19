using UnityEngine;

public class Input_Joystick : MonoBehaviour, IInputHandler
{
    private DynamicJoystick joystick;

    private void Awake()
    {
        joystick = FindAnyObjectByType<DynamicJoystick>();
        if (joystick == null)
            Debug.Log("input_joystick.cs -awake()  참조실패");
    }

    public Vector2 GetInput()
    {
        if (joystick == null)
            return Vector2.zero;

        return new Vector2(joystick.Horizontal, joystick.Vertical);

    }

   
}
