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
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue; // ������ ���� �� �ð� ����
    protected bool IsAttacking { get; set; } // ������ ���� bool

    protected CharacterStatsHandler Stats { get; private set; }
    // �����ڵ鷯 ������Ʈ ���� ����

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay(); // ���� ������ ó�� �޼��� �����Ӹ��� ȣ��
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;
        // ���� ���� ������ ������ ����ó��

        if (_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        // ������ ���ݽð��� ���� ������ �ð� ���� ������
        {
            _timeSinceLastAttack += Time.deltaTime; // ������ ���� �ð� ������Ʈ
        }

        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        // ���� ��ư ���� + ������ ���� �ð��� ���� ������ ���� ũ�ٸ�
        {
            _timeSinceLastAttack = 0; // ������ ���� �ð��� �ʱ�ȭ
            CallAttackEvent(Stats.CurrentStats.attackSO); // ���� �̺�Ʈ ȣ��
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

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO); // ���� �̺�Ʈ �߻�
    }
}
