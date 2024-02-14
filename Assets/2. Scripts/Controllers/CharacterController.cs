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
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue; // 마지막 공격 후 시간 변수
    protected bool IsAttacking { get; set; } // 공격중 여부 bool

    protected virtual void Update()
    {
        HandleAttackDelay(); // 공격 딜레이 처리 메서드 프레임마다 호출
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.2f) // 마지막 공격시간이 공격 딜레이 시간(0.2f) 보다 작으면
        {
            _timeSinceLastAttack += Time.deltaTime; // 마지막 공격 시간 업데이트
        }

        if (IsAttacking && _timeSinceLastAttack > 0.2f) 
            // 공격 버튼 눌림 + 마지막 공격 시간이 공격 딜레이(0.2초) 보다 크다면
        {
            _timeSinceLastAttack = 0; // 마지막 공격 시간을 초기화
            CallAttackEvent(); // 공격 이벤트 호출
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

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke(); // 공격 이벤트 발생
    }
}
