using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Input 시스템과 연동
    //이벤트 선언
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue; // 마지막 공격 후 시간 변수
    protected bool IsAttacking { get; set; } // 공격중 여부 bool

    protected CharacterStatsHandler Stats { get; private set; }
    // 스탯핸들러 컴포넌트 스탯 참조

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay(); // 공격 딜레이 처리 메서드 프레임마다 호출
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;
        // 공격 관련 데이터 없으면 예외처리

        if (_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        // 마지막 공격시간이 공격 딜레이 시간 보다 작으면
        {
            _timeSinceLastAttack += Time.deltaTime; // 마지막 공격 시간 업데이트
        }

        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        // 공격 버튼 눌림 + 마지막 공격 시간이 공격 딜레이 보다 크다면
        {
            _timeSinceLastAttack = 0; // 마지막 공격 시간을 초기화
            CallAttackEvent(Stats.CurrentStats.attackSO); // 공격 이벤트 호출
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // 이동 이벤트 발생
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); // 마우스 look 이벤트 발생
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO); // 공격 이벤트 발생
    }
}
