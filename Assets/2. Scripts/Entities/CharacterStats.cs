using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType // ���� ������
{
    Add, // �߰�
    Multiple, // ��
    Override, // �����
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType; // ���� ���� Ÿ��
    [Range(1, 1000)] public int maxHealth; // ü�� �ִ밪 1000
    [Range(1f, 20f)] public float speed; // �̵��ӵ�

    public AttackSO attackSO; // AttackSO ����
}