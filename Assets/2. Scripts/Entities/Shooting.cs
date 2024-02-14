using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _contoller; // CharacterController참조

    [SerializeField] private Transform BulletSpawnPosition; // 탄환 스폰 위치 지정용 (유니티)
    
    public GameObject BulletPrefab; // 탄환 프리팹 지정용 (유니티)

    private Vector2 _aimDirection = Vector2.right; // 기본 조준 방향

    private void Awake()
    {
        _contoller = GetComponent<CharacterController>(); // CharacterController 컴포넌트를 가져와 참조
    }

    void Start()
    {
        //_contoller.OnAttackEvent += OnShoot; // OnAttackEvent에 OnShoot 메소드 연결
        _contoller.OnLookEvent += OnAim; // OnLookEvent 이벤트에 OnAim 메소드 연결
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection; // 조준 방향 업데이트
    }

    private void OnShoot()
    {
        CreateProjectile(); // 탄환 생성 메서드 호출
    }

    private void CreateProjectile() // 탄환(프리팹) 생성
    {
        Instantiate(BulletPrefab, BulletSpawnPosition.position, Quaternion.identity); // 프리팹을 기반으로 발사체를 생성합니다.
    }
}

