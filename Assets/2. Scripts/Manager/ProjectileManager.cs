using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem; //파티클 시스템

    public static ProjectileManager instance;

    [SerializeField] private GameObject testObj; // 투사체 프리팹 (유니티)

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedAttackData attackData)
    {
        // 투사체 인스턴스화
        GameObject obj = Instantiate(testObj);

        
        obj.transform.position = startPostiion;

        // 투사체 RangedAttackController 컴포넌트 초기화
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }

}