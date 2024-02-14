using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f; //  ü�� ���� ���� �ð�
    private CharacterStatsHandler _statsHandler;
    private float _timeSinceLastChange = float.MaxValue; // ������ ü�� ���� ���� �ð�

    // ü�� ��ȯ �̺�Ʈ��
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; } // ���� ü��

    public float MaxHealth => _statsHandler.CurrentStats.maxHealth; 
    // �ִ� ü��(CharacterStatHandler.cs ����)

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;
        // ���� �����ϸ� ���� ü�� = �ִ� ü������ ����
    }

    private void Update()
    {
        if (_timeSinceLastChange < healthChangeDelay) // ü�� ���� ���� �ð��� ��������
        {
            _timeSinceLastChange += Time.deltaTime; // �ð� ������Ʈ
            if (_timeSinceLastChange >= healthChangeDelay) // ü�� ���� ���� �ð��� ������ 
            {
                OnInvincibilityEnd?.Invoke(); // ���� ���� ���� �̺�Ʈ ȣ��
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || _timeSinceLastChange < healthChangeDelay)
        // ���� ���� or ���� �ð��� ������ �ʾҴٸ� false(����x)
        {
            return false;
        }

        _timeSinceLastChange = 0f; // �ð� �ʱ�ȭ
        CurrentHealth += change; // ü�� ����
        //CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        //CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        // ���� ü�� = 0 ~ �ִ�ü�� ����


        if (change > 0)
        {
            OnHeal?.Invoke(); // ü���� ȸ���Ǹ� OnHeal �̺�Ʈ
        }
        else
        {
            OnDamage?.Invoke(); // ü���� �����ϸ� OnDamage �̺�Ʈ
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath(); // ü���� 0���ϸ� CallDeath �޼��� ȣ��
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke(); // OnDeath �̺�Ʈ ȣ��
    }
}