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
        // 상위 클래스(CommonAnimations)의 Awake 메소드 호출
        // = animator, controller 참조


        _healthSystem = GetComponent<HealthSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {

        controller.OnAttackEvent += Attacking; // 공격 이벤트 연결
        controller.OnMoveEvent += Move; // 이동 이벤트 연결

        if (_healthSystem != null)
        {
            _healthSystem.OnDamage += Hit; // hit 이벤트 연결
            _healthSystem.OnInvincibilityEnd += InvincibilityEnd;
            // InvincibilityEnd(무적 상태 종료) 이벤트 연결
        }
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > .5f);
        // 이동속도 적용 되면 이동 애니메이션 재생
        Debug.Log("walking");
    }

    private void Attacking(AttackSO obj)
    {
        animator.SetTrigger(Attack);  // 공격 애니메이션 재생
    }

    private void Hit()
    {
        animator.SetBool(IsHit, true); // 피격 애니메이션 재생
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false); // 피격 애니메이션 종료
    }



}
