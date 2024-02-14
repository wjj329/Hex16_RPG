using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f; //  체력 변경 지연 시간
    private CharacterStatsHandler _statsHandler;
    private float _timeSinceLastChange = float.MaxValue; // 마지막 체력 변경 이후 시간

    // 체력 변환 이벤트들
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; } // 현재 체력

    public float MaxHealth => _statsHandler.CurrentStats.maxHealth; 
    // 최대 체력(CharacterStatHandler.cs 참조)

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;
        // 게임 시작하면 현재 체력 = 최대 체력으로 설정
    }

    private void Update()
    {
        if (_timeSinceLastChange < healthChangeDelay) // 체력 변경 지연 시간이 지났는지
        {
            _timeSinceLastChange += Time.deltaTime; // 시간 업데이트
            if (_timeSinceLastChange >= healthChangeDelay) // 체력 변경 지연 시간이 끝나면 
            {
                OnInvincibilityEnd?.Invoke(); // 무적 상태 종료 이벤트 호출
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || _timeSinceLastChange < healthChangeDelay)
        // 변경 없음 or 지연 시간이 지나지 않았다면 false(변경x)
        {
            return false;
        }

        _timeSinceLastChange = 0f; // 시간 초기화
        CurrentHealth += change; // 체력 변경
        //CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        //CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        // 현재 체력 = 0 ~ 최대체력 사이


        if (change > 0)
        {
            OnHeal?.Invoke(); // 체력이 회복되면 OnHeal 이벤트
        }
        else
        {
            OnDamage?.Invoke(); // 체력이 감소하면 OnDamage 이벤트
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath(); // 체력이 0이하면 CallDeath 메서드 호출
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke(); // OnDeath 이벤트 호출
    }
}