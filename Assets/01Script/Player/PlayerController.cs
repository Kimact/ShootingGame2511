using UnityEngine;

public class PlayerController : MonoBehaviour, IManager
{
    private IMovement movement;
    private IInputHandler inputHandler;

    public void GameInitialize()
    {
        throw new System.NotImplementedException();
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

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInput>() as IInputHandler;
        movement = GetComponent<PlayerInput> () as IMovement; // IMovement 로 형변환하고 movement 에 참조를 걸어줌.


        movement?.SetEnable(true);
    }

    void IManager.GameTick(float delta)
    {
        if (movement == null) return;
        if (inputHandler == null) return;

        movement.Move(inputHandler.GetInput());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
