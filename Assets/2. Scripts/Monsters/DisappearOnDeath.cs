using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnDeath : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthSystem.OnDeath += OnDeath;
    }

    void OnDeath()
    {
        _rigidbody.velocity = Vector3.zero; // ����� ĳ���� ����

        foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
            // ����� ��������Ʈ ������ ���� 0.3���� �帮��
        }

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
            // ������Ʈ ��Ȱ��ȭ ( ��ũ��Ʈ ����, �ִϸ��̼� ���� )
        }

        Destroy(gameObject, 2f); // 2�� �� ����� ������Ʈ �ı�
    }
}