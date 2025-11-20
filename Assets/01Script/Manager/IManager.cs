using UnityEngine;

public interface IManager
{
    void GameInitialize();
    void GameStart();
    void GamePause();
    void GameResume();
    void GameOver();
    void GameTick(float delta);

    
}
