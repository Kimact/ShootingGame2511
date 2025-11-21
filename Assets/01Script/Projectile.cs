using UnityEngine;

// 지정된 방향으로 지정된 속도로 지속적으로 이동하는 기능.
// 발사 시켜준 onwer 주체와 다른팀의 대상과 닿았을때, 상대방에게 데미지 전달.

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IMovement
{
    public enum projectleType
    {
        player01, player02, player03, 
        boss01, boss02, boss03
    };

    //스크립터블 오브젝트
    //데이터 매니저

    //절차지향적 프로그래핑
    //객체지향적 프로그래핑
    //DI 의존성 주입
    //Data-Driven-Programing

    private float moveSpeed = 10f;
    private int damage;
    private Vector2 moveDir;
    private GameObject owner;
    private string ownerTag;

    private bool isInit = false;
    private projectleType type;

    private void Awake()
    {
        if (TryGetComponent<CircleCollider2D>(out CircleCollider2D col)) 
        {
            col.radius = 0.1f;
            col.isTrigger = true;
        }
        if(TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.gravityScale = 0f;
        }
    }
    public void InitProjectile(projectleType newtype, Vector2 newDir, GameObject newOwner,
        int newDamage, float newSpeed)
    {
        type = newtype;
        moveDir = newDir;
        owner = newOwner;
        ownerTag = owner.name;
        damage = newDamage;
        moveSpeed = newSpeed;
        SetEnable(true);
    }
    void Update()
    {
        if (isInit)
        {
            Move(Time.deltaTime, moveDir);
        }
    }
    public void Move(float delta, Vector2 direction)
    {
        transform.Translate(direction * (moveSpeed * delta));
    }

    public void SetEnable(bool newEnable)
    {
        isInit = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == owner)
        {
            return; //얼리 리턴 코딩스타일
        }
        if (collision.CompareTag(ownerTag))// 보스가쏜 투사체를 몬스터들이 맞으면 안됨.
            return;

        if (collision.CompareTag("DestroyArea"))
        {
            ProjectileManager.Inst.ReturnProjectileToPool(this, type);
            return; // 파괴
        }

        if(collision.TryGetComponent<IDamaged>(out IDamaged component))
        {

            component.TakeDamage(owner, damage);
            ProjectileManager.Inst.ReturnProjectileToPool(this, type);
            return;
        }
    }

}
