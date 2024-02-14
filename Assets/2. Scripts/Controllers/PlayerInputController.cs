using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    private Camera _camera;
    protected override void Awake()
    {
        base.Awake(); 
        _camera = Camera.main; // ���� ī�޶� ����
    }

    public void OnMove(InputValue value) // �÷��̾� ������ �Է�
    {
        Vector2 moveInput = value.Get<Vector2>().normalized; // �Է°��� vector2�� ��ȯ + ����ȭ
        CallMoveEvent(moveInput); // ��ȯ�� �Է°� CallMoveEvent �̺�Ʈ�� ����
    }

    public void OnLook(InputValue value) // �÷��̾� ���콺 �Է� 
    { 
        Vector2 newAim = value.Get<Vector2>(); // ���콺 �Է°�
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim); // (���콺 Ŀ��)��ũ�� ��ǥ -> ���� ��ǥ
        newAim = (worldPos - (Vector2)transform.position).normalized;
        // �÷��̾� ��ġ �������� ���� ����

        if (newAim.magnitude >= .9f)
        // Vector ���� �Ǽ��� ��ȯ => ���콺 �ν� �ΰ��� ����
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value) // �÷��̾� �߻� �Է�
    {
        IsAttacking = value.isPressed; // �߻� ��ư ������ ȣ��
    }
}


