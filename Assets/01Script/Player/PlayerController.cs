using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovement movement;
    private IInputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInput>() as IInputHandler;
        movement = GetComponent<PlayerMovement>() as IMovement;

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
