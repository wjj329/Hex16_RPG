using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem; //��ƼŬ �ý���

    public static ProjectileManager instance;

    [SerializeField] private GameObject testObj; // ����ü ������ (����Ƽ)

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedAttackData attackData)
    {
        // ����ü �ν��Ͻ�ȭ
        GameObject obj = Instantiate(testObj);

        
        obj.transform.position = startPostiion;

        // ����ü RangedAttackController ������Ʈ �ʱ�ȭ
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }

}