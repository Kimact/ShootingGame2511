using System.Collections;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    private IManager playerManager;
    bool isPlaying = false;
    private void Awake()
    {
  
    
        GameObject obj;
        obj = GameObject.Find("Player");
        if(obj != null )
        {
            playerManager = obj.GetComponent<IManager>();
        }

        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        yield return null;
        playerManager?.GameInitialize();

        for (int i = 5; i >= 0; --i) 
        {
            Debug.Log($"게임시작 준비중....{i}");
            yield return new WaitForSeconds(2f);
        }
        isPlaying = true;

        playerManager?.GameStart();
        yield return new WaitForSeconds(2f);
    }
    private void Update()
    {
        if(isPlaying)
        {
            playerManager?.GameTick(Time.deltaTime);
        }
    }
}
