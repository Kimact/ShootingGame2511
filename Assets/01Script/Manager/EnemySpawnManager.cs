using System;
using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour, IManager
{
    [SerializeField] private Transform[] spawnTrans;
    [SerializeField] private GameObject[] spawnPrefabs;

    public static Action OnSpawnFinish; // 일반 몬스터 스폰이 종료되었다.

    private float spawnDelta = 1f;
    private int spawnLevel = 0;
    private int spawnCount = 7;

    // wave -> 일반 몬스터 7번 + 보스 1번 스테이지 웨이브 등 
        
    public void GameInitialize()
    {
        spawnLevel = 0;
        spawnCount = 7;
        spawnDelta = 1f;

        StartCoroutine(StartWave());
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
        throw new System.NotImplementedException();
    }

    public void GameTick(float delta)
    {
        throw new System.NotImplementedException();
    }

    private GameObject go;
    IEnumerator StartWave()
    {
        while (spawnCount > 0)
        {
            for (int i = 0; i < spawnTrans.Length; i++)
            {
                go = Instantiate(spawnPrefabs[spawnLevel], spawnTrans[i].position, Quaternion.identity);
                if (go.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.SetEnable(true);
                }
                spawnCount--;
                yield return new WaitForSeconds(spawnDelta);
            }
            OnSpawnFinish?.Invoke();

            spawnLevel++;
            if(spawnLevel >= 3)
            {
                spawnLevel = 0;
            }
            spawnCount = 7;
        }
    }
}
