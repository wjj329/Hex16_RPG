using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rigidbody;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero; /// 현재 움직임 방향

    private Vector2 _knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move; 
        // OnMoveEvent이벤트에 Move 메소드 연결
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
        // 움직임 방향에 따라 물리 움직임 적용

        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
        // 입력된 움직임 방향 저장
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    { // 넉백 적용
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    } 

    private void ApplyMovment(Vector2 direction)
    {
        // 이동속도 설정
        direction = direction * _stats.CurrentStats.speed;

        if (knockbackDuration > 0.0f)
        {
            direction += _knockback;
        }

        _rigidbody.velocity = direction;
        // Rigidbody의 속도를 설정하여 움직임을 적용
    }
}
