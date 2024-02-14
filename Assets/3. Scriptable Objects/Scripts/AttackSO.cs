using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed; // 공격 속도
    public LayerMask target; // 공격 대상 레이어

    [Header("Knock Back Info")]
    public bool isOnKnockback; // 넉백 적용 여부
    public float knockbackPower;
    public float knockbackTime;
}