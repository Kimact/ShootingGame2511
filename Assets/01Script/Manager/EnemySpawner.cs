using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnRangeX = 2f;
    [SerializeField] private float spawnPositionY = 6f;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemySpawner: enemyPrefab is not assigned!");
            return;
        }

        // 랜덤 X 위치 생성
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnPositionY, 0f);

        // 에너미 생성
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log($"Enemy spawned at {spawnPosition}");
    }

    // Gizmo로 스폰 범위 표시
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-spawnRangeX, spawnPositionY, 0f),
                       new Vector3(spawnRangeX, spawnPositionY, 0f));
    }
}
