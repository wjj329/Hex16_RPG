using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthSystem healthSystem; // 체력 시스템 참조
    public Image healthBarImage; // 체력바 UI

    private void Start()
    {
        if (healthSystem == null)
        {
            Debug.LogError("체력 시스템 디버그", this);
            return;
        }


        healthSystem.OnDamage += UpdateHealthBar; // 데미지 이벤트에 UI 업데이트 연결
        healthSystem.OnHeal += UpdateHealthBar; // 회복 이벤트
        UpdateHealthBar(); // 초기 UI 설정
    }

    private void UpdateHealthBar()
    {
        if (healthSystem != null)
        {
            // 체력바 UI의 fillAmount = 현재 체력 / 최대 체력
            healthBarImage.fillAmount = healthSystem.CurrentHealth / healthSystem.MaxHealth;
        }
    }

    private void OnDestroy()
    {

        // 오브젝트가 파괴될 때 이벤트 해제
        healthSystem.OnDamage -= UpdateHealthBar;
        healthSystem.OnHeal -= UpdateHealthBar;
    }
}
