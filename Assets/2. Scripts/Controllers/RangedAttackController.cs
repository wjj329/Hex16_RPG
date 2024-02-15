using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    // 충돌 감지용 레이어 마스크
    [SerializeField] private LayerMask levelCollisionLayer;

    private RangedAttackData _attackData;
    private float _currentDuration; // 발사후 시간
    private Vector2 _direction; // 발사 방향
    private bool _isReady; // 발사 준비 bool

    private Rigidbody2D _rigidbody; // 물리
    private SpriteRenderer _spriteRenderer; // 투사체 스프라이트
    private TrailRenderer _trailRenderer; // 트레일 렌더러
    private ProjectileManager _projectileManager; // 프로젝타일 매니저 참조

    public bool fxOnDestory = true; // 파괴시 파티클 효과

    private void Awake()
    {
        // 컴포넌트 초기화
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }
    
    private void Update()
    {
        if (!_isReady) // 예외처리
        {
            return;
        }

        _currentDuration += Time.deltaTime; // 투사체 지속시간 갱신

        if (_currentDuration > _attackData.duration) // 지속시간 끝나면 파괴
        {
            DestroyProjectile(transform.position, false);
        }
        
        //물리 효과로 발사
        _rigidbody.velocity = _direction * _attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌 객체가 지정 레이어(맵: level)와 충돌했다면
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            //투사체를 파괴
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestory);
        }

        // 투사체가 공격 대상 레이어(몬스터)와 충돌했다면
        else if (_attackData.target.value == (_attackData.target.value | (1 << collision.gameObject.layer)))
        {

            // 충돌한 오브젝트에서 HealthSystem 컴포넌트 호출
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                //  공격력만큼 대상 체력 감소
                healthSystem.ChangeHealth(-_attackData.power);

                // 넉백 있으면 넉백 적용
                if (_attackData.isOnKnockback)
                {
                    // 충돌 오브젝트에서 Movement 컴포넌트 호출
                    Movement movement = collision.GetComponent<Movement>();
                    if (movement != null)
                    {
                        // 넉백 적용
                        movement.ApplyKnockback(transform, _attackData.knockbackPower, _attackData.knockbackTime);
                    }
                }
            }
            // 투사체 파괴
            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
        }
    }


    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {//투사체 초기화 메서드
        _projectileManager = projectileManager; // ProjectileManager 할당
        _attackData = attackData; // 공격 데이터
        _direction = direction; // 발사 방향

        //투사체 시각 효과
        UpdateProjectilSprite(); 
        _trailRenderer.Clear();
        _currentDuration = 0;
        _spriteRenderer.color = attackData.projectileColor;

        transform.right = _direction;

        _isReady = true;
    }

    private void UpdateProjectilSprite()
    {
        // 투사체의 크기 조정
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        //파괴시 효과
        if (createFx)
        {
            // 파티클 
        }
        gameObject.SetActive(false); 
    }
}