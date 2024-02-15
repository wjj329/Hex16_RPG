using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rigidbody;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero; /// ���� ������ ����

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
        // OnMoveEvent�̺�Ʈ�� Move �޼ҵ� ����
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
        // ������ ���⿡ ���� ���� ������ ����

        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
        // �Էµ� ������ ���� ����
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    { // �˹� ����
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    } 

    private void ApplyMovment(Vector2 direction)
    {
        // �̵��ӵ� ����
        direction = direction * _stats.CurrentStats.speed;

        if (knockbackDuration > 0.0f)
        {
            direction += _knockback;
        }

        _rigidbody.velocity = direction;
        // Rigidbody�� �ӵ��� �����Ͽ� �������� ����
    }
}
