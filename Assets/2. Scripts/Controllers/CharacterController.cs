using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Input �ý��۰� ����
    //�̺�Ʈ ����
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue; // ������ ���� �� �ð� ����
    protected bool IsAttacking { get; set; } // ������ ���� bool

    protected virtual void Update()
    {
        HandleAttackDelay(); // ���� ������ ó�� �޼��� �����Ӹ��� ȣ��
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.2f) // ������ ���ݽð��� ���� ������ �ð�(0.2f) ���� ������
        {
            _timeSinceLastAttack += Time.deltaTime; // ������ ���� �ð� ������Ʈ
        }

        if (IsAttacking && _timeSinceLastAttack > 0.2f) 
            // ���� ��ư ���� + ������ ���� �ð��� ���� ������(0.2��) ���� ũ�ٸ�
        {
            _timeSinceLastAttack = 0; // ������ ���� �ð��� �ʱ�ȭ
            CallAttackEvent(); // ���� �̺�Ʈ ȣ��
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // �̵� �̺�Ʈ �߻�
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); // ���콺 look �̺�Ʈ �߻�
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke(); // ���� �̺�Ʈ �߻�
    }
}
