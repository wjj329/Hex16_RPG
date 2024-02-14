using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero; /// ���� ������ ����


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
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
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
        // �Էµ� ������ ���� ����
    }

    private void ApplyMovment(Vector2 direction)
    {
        // �̵��ӵ� ����
        direction *= 5; 

        _rigidbody.velocity = direction; 
        // Rigidbody�� �ӵ��� �����Ͽ� �������� ����
    }
}
