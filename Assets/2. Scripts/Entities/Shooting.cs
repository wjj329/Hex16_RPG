using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _contoller; // CharacterController참조

    [SerializeField] private Transform projectileSpawnPosition; // 탄환 스폰 위치 지정용 (유니티)

    private ProjectileManager _projectileManager; // 프로젝타일 매니저 참조

    private Vector2 _aimDirection = Vector2.right; // 기본 조준 방향

    private void Awake()
    {
        _contoller = GetComponent<CharacterController>(); // CharacterController 컴포넌트를 가져와 참조
    }

    void Start()
    {
        _projectileManager = ProjectileManager.instance;
        _contoller.OnAttackEvent += OnShoot;
        _contoller.OnLookEvent += OnAim;
    }


    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection; // 조준 방향 업데이트
    }

    private void OnShoot(AttackSO attackSO)
    {
        // attackSO에서 RangedAttackData로 형 변환
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;

        // 각 발사체 사이 각도
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;

        // 샷 당 발사체의 수
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        // 첫 발사체 각도 계산
        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


        //설정 발사체 수만큼 발사체 생성
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            // 각 발사체 각도 계산
            float angle = minAngle + projectilesAngleSpace * i;

            // 발사체 각도 랜덤 분산
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;

            CreateProjectile(rangedAttackData, angle); // 발사체 생성 메서드 호출
        }
    }

    // ProjectileManager.ShootBullet 메서드 호출
    // 위치와 방향 = 각도에 따라 조정
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

