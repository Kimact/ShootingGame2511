using UnityEngine;

public class PlayerWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private Projectile.projectleType projectileType;
    [SerializeField] private Transform fireTrans;

    [Header("발사관련 Data")]
    [SerializeField] private int numOfProjectiles = 5;
    [SerializeField] private float fireRate = 0.3f; // 투사체 발사와 발사 사이 간격. 시간.
    [SerializeField] private float spreadAngle = 5; // 투사체가 여러발 발사 될때, 발사 간의 간격.
    
    private float nextFireTime;
    private bool isFiring = false;

    //연산
    float StartAngle;
    float angle;
    Quaternion fireRotation;
    GameObject go;
    Projectile projectileComp;


    public void SetEnable(bool newEnable)
    {
        isFiring = newEnable;
        if(newEnable )
        {
            nextFireTime = 0f;
        }
    }

    public void SetFire()
    {
        if (Time.time < nextFireTime)
            return;
        if (!isFiring)
            return;

        nextFireTime = Time.time + fireRate;

        StartAngle = -spreadAngle * (numOfProjectiles - 1) / 2f;

        for(int i =0; i< numOfProjectiles; i++)
        {
            angle = StartAngle + spreadAngle * i;

            fireRotation = fireTrans.rotation * Quaternion.Euler(0, 0, angle);
            Vector2 fireDir = fireRotation * Vector2.up;
            ProjectileManager.Inst.FireProjectile(projectileType, 
                                                fireTrans.position, 
                                                fireDir, 
                                                gameObject, 
                                                1, 
                                                10f);
        }
    }

    public void SetOwner(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
