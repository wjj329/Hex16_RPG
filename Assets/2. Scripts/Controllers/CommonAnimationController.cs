using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAnimationController : CommonAnimations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    private HealthSystem _healthSystem;

    protected override void Awake()
    {
        base.Awake();
        // ���� Ŭ����(CommonAnimations)�� Awake �޼ҵ� ȣ��
        // = animator, controller ����


        _healthSystem = GetComponent<HealthSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {

        controller.OnAttackEvent += Attacking; // ���� �̺�Ʈ ����
        controller.OnMoveEvent += Move; // �̵� �̺�Ʈ ����

        if (_healthSystem != null)
        {
            _healthSystem.OnDamage += Hit; // hit �̺�Ʈ ����
            _healthSystem.OnInvincibilityEnd += InvincibilityEnd;
            // InvincibilityEnd(���� ���� ����) �̺�Ʈ ����
        }
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > .5f);
        // �̵��ӵ� ���� �Ǹ� �̵� �ִϸ��̼� ���
        Debug.Log("walking");
    }

    private void Attacking(AttackSO obj)
    {
        animator.SetTrigger(Attack);  // ���� �ִϸ��̼� ���
    }

    private void Hit()
    {
        animator.SetBool(IsHit, true); // �ǰ� �ִϸ��̼� ���
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false); // �ǰ� �ִϸ��̼� ����
    }



}
