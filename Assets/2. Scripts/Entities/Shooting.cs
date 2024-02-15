using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _contoller; // CharacterController����

    [SerializeField] private Transform projectileSpawnPosition; // źȯ ���� ��ġ ������ (����Ƽ)

    private ProjectileManager _projectileManager; // ������Ÿ�� �Ŵ��� ����

    private Vector2 _aimDirection = Vector2.right; // �⺻ ���� ����

    private void Awake()
    {
        _contoller = GetComponent<CharacterController>(); // CharacterController ������Ʈ�� ������ ����
    }

    void Start()
    {
        _projectileManager = ProjectileManager.instance;
        _contoller.OnAttackEvent += OnShoot;
        _contoller.OnLookEvent += OnAim;
    }


    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection; // ���� ���� ������Ʈ
    }

    private void OnShoot(AttackSO attackSO)
    {
        // attackSO���� RangedAttackData�� �� ��ȯ
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;

        // �� �߻�ü ���� ����
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;

        // �� �� �߻�ü�� ��
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        // ù �߻�ü ���� ���
        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


        //���� �߻�ü ����ŭ �߻�ü ����
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            // �� �߻�ü ���� ���
            float angle = minAngle + projectilesAngleSpace * i;

            // �߻�ü ���� ���� �л�
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;

            CreateProjectile(rangedAttackData, angle); // �߻�ü ���� �޼��� ȣ��
        }
    }

    // ProjectileManager.ShootBullet �޼��� ȣ��
    // ��ġ�� ���� = ������ ���� ����
    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
                projectileSpawnPosition.position,
                RotateVector2(_aimDirection, angle),
                rangedAttackData
                );
    }
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}

