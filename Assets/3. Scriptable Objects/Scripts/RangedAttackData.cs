using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag; // 탄환 이름 태그
    public float duration; // 지속 시간
    public float spread; // 분산도
    public int numberofProjectilesPerShot; // 한 번에 발사되는 탄환 수
    public float multipleProjectilesAngel; // 여러발 발사 시 각도
    public Color projectileColor;
}