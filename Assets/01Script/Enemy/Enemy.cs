using UnityEngine;

public class Enemy : MonoBehaviour, IDamaged
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private float moveSpeed = 2f;

    private void Start()
    {
        currentHealth = maxHealth;
        // 에너미 태그 설정
        gameObject.tag = "Enemy";
    }

    private void Update()
    {
        // 아래로 이동
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // 화면 밖으로 나가면 삭제
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(GameObject attacker, int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy took {damage} damage. Current Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 충돌 시 플레이어에게 데미지
        if (collision.CompareTag("Player"))
        {
            IDamaged player = collision.GetComponent<IDamaged>();
            if (player != null)
            {
                player.TakeDamage(gameObject, 10);
            }
            Die();
        }

        // 플레이어 총알과 충돌 시
        if (collision.CompareTag("PlayerBullet"))
        {
            TakeDamage(collision.gameObject, 10);
            Destroy(collision.gameObject);
        }
    }
}
