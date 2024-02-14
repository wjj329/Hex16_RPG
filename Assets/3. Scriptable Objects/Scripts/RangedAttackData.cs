using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag; // źȯ �̸� �±�
    public float duration; // ���� �ð�
    public float spread; // �л굵
    public int numberofProjectilesPerShot; // �� ���� �߻�Ǵ� źȯ ��
    public float multipleProjectilesAngel; // ������ �߻� �� ����
    public Color projectileColor;
}