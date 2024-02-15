using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem; //파티클 시스템

    public static ProjectileManager instance;

    [SerializeField] private GameObject testObj; // 투사체 프리팹 (유니티)

    private ObjectPool objectPool; // 투사체 재사용(오브젝트 풀) 컴퍼넌트 참조

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        // 게임 오브젝트 ObjectPool 컴포넌트 호출
    }

    public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedAttackData attackData)
    {
        // 오브젝트 풀에서 오브젝트 스폰
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);

        obj.transform.position = startPostiion;

        // 투사체 RangedAttackController 컴포넌트 초기화
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }

}