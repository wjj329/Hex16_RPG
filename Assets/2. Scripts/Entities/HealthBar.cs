using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthSystem healthSystem; // ü�� �ý��� ����
    public Image healthBarImage; // ü�¹� UI

    private void Start()
    {
        if (healthSystem == null)
        {
            Debug.LogError("ü�� �ý��� �����", this);
            return;
        }


        healthSystem.OnDamage += UpdateHealthBar; // ������ �̺�Ʈ�� UI ������Ʈ ����
        healthSystem.OnHeal += UpdateHealthBar; // ȸ�� �̺�Ʈ
        UpdateHealthBar(); // �ʱ� UI ����
    }

    private void UpdateHealthBar()
    {
        if (healthSystem != null)
        {
            // ü�¹� UI�� fillAmount = ���� ü�� / �ִ� ü��
            healthBarImage.fillAmount = healthSystem.CurrentHealth / healthSystem.MaxHealth;
        }
    }

    private void OnDestroy()
    {

        // ������Ʈ�� �ı��� �� �̺�Ʈ ����
        healthSystem.OnDamage -= UpdateHealthBar;
        healthSystem.OnHeal -= UpdateHealthBar;
    }
}
