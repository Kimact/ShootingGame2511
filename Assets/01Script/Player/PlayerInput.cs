using UnityEngine;

public class PlayerInput : MonoBehaviour, IInputHandler
{
    private IInputHandler curInputHandle;

    private void Awake()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        curInputHandle = GetComponent<Input_KeyBoard>() as IInputHandler;
#endif

#if UNITY_ANDROID || UNITY_IOS
    curInputHandle = GetComponent <Input_Joystick() as IInputHandler;
#endif
    }
    public Vector2 GetInput()
    {

        if (curInputHandle == null)
        {
            Debug.Log("PlayerInput.cs _ GetInput() - curInputHandle is NULL");
            return Vector2.zero;
        }
        return curInputHandle.GetInput();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"입력값 확인 {GetInput()}");
    }
}
