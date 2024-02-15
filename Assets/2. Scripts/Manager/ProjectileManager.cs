using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem; //��ƼŬ �ý���

    public static ProjectileManager instance;

    [SerializeField] private GameObject testObj; // ����ü ������ (����Ƽ)

    private ObjectPool objectPool; // ����ü ����(������Ʈ Ǯ) ���۳�Ʈ ����

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        // ���� ������Ʈ ObjectPool ������Ʈ ȣ��
    }

    public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedAttackData attackData)
    {
        // ������Ʈ Ǯ���� ������Ʈ ����
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);

        obj.transform.position = startPostiion;

        // ����ü RangedAttackController ������Ʈ �ʱ�ȭ
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }

}