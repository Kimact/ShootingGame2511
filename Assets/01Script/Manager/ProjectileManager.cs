using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : SingleTon<ProjectileManager>
{
    [SerializeField] private GameObject[] projectilePrefab;
    private static Queue<Projectile>[] projectiles;
    private int poolSize = 10;


    protected override void DoAwake()
    {
        base.DoAwake();
        projectiles = new Queue<Projectile>[projectilePrefab.Length];
        // awake에서 하는 이유는 인스펙터 창에서 

        for(int i =0; i< projectilePrefab.Length; ++i)
        {
            projectiles[i] = new Queue<Projectile>();
            Allocate((Projectile.projectleType)i);
        }
    }
    
    private void Allocate(Projectile.projectleType type)
    {
        GameObject go;
        for(int i=0; i<poolSize;++i)
        {
            go = Instantiate(projectilePrefab[(int)type]);

            if(go.TryGetComponent<Projectile>(out Projectile projectile))
            {
                projectiles[(int)type].Enqueue(projectile); // 큐<스크립트 객체 기준>에 추가
            }
            go.SetActive(false);
        }
    }
    public void FireProjectile(Projectile.projectleType type, 
                                Vector3 spawnPos, 
                                Vector2 direction,
                                GameObject owner, 
                                int damage, 
                                float speed)
    {
        Projectile proj = GetProjectileFromPool(type);

        if(proj != null)
        {
            proj.transform.position = spawnPos;
            proj.gameObject.SetActive(true);
            proj.InitProjectile(type, direction, owner, damage, speed);
        }
    }
    private Projectile GetProjectileFromPool(Projectile.projectleType type)
    {
        if (projectiles[(int)type].Count < 1)
            Allocate(type);

        return projectiles[(int)type].Dequeue();
    }

    public void ReturnProjectileToPool(Projectile returnProj, Projectile.projectleType type)
    {
        returnProj.gameObject.SetActive(false);
        projectiles[(int)type].Enqueue(returnProj);
    }
   
}
