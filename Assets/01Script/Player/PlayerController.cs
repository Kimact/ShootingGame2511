using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovement movement;
    private IInputHandler inputHandler;

    private void Start()
    {
        inputHandler = GetComponent<PlayerInput>() as IInputHandler;
        movement = GetComponent<PlayerMovement>() as IMovement;

        if (inputHandler == null)
            Debug.LogError("PlayerController: PlayerInput component not found!");
        if (movement == null)
            Debug.LogError("PlayerController: PlayerMovement component not found!");

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
