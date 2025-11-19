using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovement movement;
    private IInputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInput>() as IInputHandler;
        movement = GetComponent<PlayerInput> () as IMovement; // IMovement 로 형변환하고 movement 에 참조를 걸어줌.

        movement?.SetEnable(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement == null) return;
        if(inputHandler == null) return;
        
        movement.Move(inputHandler.GetInput());

    }
}
