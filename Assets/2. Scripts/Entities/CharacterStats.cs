using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType // 스탯 변경방식
{
    Add, // 추가
    Multiple, // 곱
    Override, // 덮어쓰기
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType; // 스탯 변경 타입
    [Range(1, 1000)] public int maxHealth; // 체력 최대값 1000
    [Range(1f, 20f)] public float speed; // 이동속도

    public AttackSO attackSO; // AttackSO 참조
}