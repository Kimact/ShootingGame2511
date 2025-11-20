using UnityEngine;

public class PlayerController : MonoBehaviour, IManager
{
    private IMovement movement;
    private IInputHandler inputHandler;

    public void GameInitialize()
    {
        inputHandler = GetComponent<PlayerInput>() as IInputHandler;
        movement = GetComponent<IMovement>();
    }

    public void GameOver()
    {
        throw new System.NotImplementedException();
    }

    public void GamePause()
    {
        throw new System.NotImplementedException();
    }

    public void GameResume()
    {
        throw new System.NotImplementedException();
    }

    public void GameStart()
    {
        movement?.SetEnable(true);
    }

    public void GameTick(float delta)
    {
        if (movement == null) return;
        if (inputHandler == null) return;

        movement.Move(delta, inputHandler.GetInput());

    }
   
}
