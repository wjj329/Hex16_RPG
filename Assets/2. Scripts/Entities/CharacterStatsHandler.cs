using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats; // �⺻ ����
    public CharacterStats CurrentStats { get; private set; } // ���� ����
    public List<CharacterStats> statsModifiers  = new List<CharacterStats>();
    // ���� ���� ��� ���帮��Ʈ


    private void Awake()
    {
        UpdateCharacterStats(); // ���� ������Ʈ
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStats = new CharacterStats { attackSO = attackSO };
        // ���� ������ ���ο� ��ü�� �ʱ�ȭ


        // �⺻ ������ ���� �������� ����
        //TODO
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;

    }
}