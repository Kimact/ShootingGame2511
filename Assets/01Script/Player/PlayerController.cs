using UnityEngine;

public class PlayerController : MonoBehaviour, IManager
{
    private IMovement movement;
    private IInputHandler inputHandler;
    private IWeapon curWeapon;

    public void GameInitialize()
    {
        inputHandler = GetComponent<PlayerInput>() as IInputHandler;
        movement = GetComponent<IMovement>();
        curWeapon = GetComponent<IWeapon>();
    }

    public void GameOver()
    {
    }

    public void GamePause()
    {
    }

    public void GameResume()
    {
    }

    public void GameStart()
    {
        movement?.SetEnable(true);
        curWeapon?.SetEnable(true);
    }

    public void GameTick(float delta)
    {
        if (movement == null) return;
        if (inputHandler == null) return;

        movement.Move(delta, inputHandler.GetInput());

        curWeapon?.SetFire();
    }
   
}
