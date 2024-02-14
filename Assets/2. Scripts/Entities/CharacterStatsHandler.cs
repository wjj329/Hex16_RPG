using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats; // 기본 스탯
    public CharacterStats CurrentStats { get; private set; } // 현재 스탯
    public List<CharacterStats> statsModifiers  = new List<CharacterStats>();
    // 스탯 변경 요소 저장리스트


    private void Awake()
    {
        UpdateCharacterStats(); // 스탯 업데이트
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStats = new CharacterStats { attackSO = attackSO };
        // 현재 스탯을 새로운 객체로 초기화


        // 기본 스탯을 현재 스탯으로 복사
        //TODO
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;

    }
}