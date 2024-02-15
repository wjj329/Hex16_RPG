using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    // �浹 ������ ���̾� ����ũ
    [SerializeField] private LayerMask levelCollisionLayer;

    private RangedAttackData _attackData;
    private float _currentDuration; // �߻��� �ð�
    private Vector2 _direction; // �߻� ����
    private bool _isReady; // �߻� �غ� bool

    private Rigidbody2D _rigidbody; // ����
    private SpriteRenderer _spriteRenderer; // ����ü ��������Ʈ
    private TrailRenderer _trailRenderer; // Ʈ���� ������
    private ProjectileManager _projectileManager; // ������Ÿ�� �Ŵ��� ����

    public bool fxOnDestory = true; // �ı��� ��ƼŬ ȿ��

    private void Awake()
    {
        // ������Ʈ �ʱ�ȭ
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }
    
    private void Update()
    {
        if (!_isReady) // ����ó��
        {
            return;
        }

        _currentDuration += Time.deltaTime; // ����ü ���ӽð� ����

        if (_currentDuration > _attackData.duration) // ���ӽð� ������ �ı�
        {
            DestroyProjectile(transform.position, false);
        }
        
        //���� ȿ���� �߻�
        _rigidbody.velocity = _direction * _attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹 ��ü�� ���� ���̾�(��: level)�� �浹�ߴٸ�
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            //����ü�� �ı�
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestory);
        }

        // ����ü�� ���� ��� ���̾�(����)�� �浹�ߴٸ�
        else if (_attackData.target.value == (_attackData.target.value | (1 << collision.gameObject.layer)))
        {

            // �浹�� ������Ʈ���� HealthSystem ������Ʈ ȣ��
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                //  ���ݷ¸�ŭ ��� ü�� ����
                healthSystem.ChangeHealth(-_attackData.power);

                // �˹� ������ �˹� ����
                if (_attackData.isOnKnockback)
                {
                    // �浹 ������Ʈ���� Movement ������Ʈ ȣ��
                    Movement movement = collision.GetComponent<Movement>();
                    if (movement != null)
                    {
                        // �˹� ����
                        movement.ApplyKnockback(transform, _attackData.knockbackPower, _attackData.knockbackTime);
                    }
                }
            }
            // ����ü �ı�
            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
        }
    }


    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {//����ü �ʱ�ȭ �޼���
        _projectileManager = projectileManager; // ProjectileManager �Ҵ�
        _attackData = attackData; // ���� ������
        _direction = direction; // �߻� ����

        //����ü �ð� ȿ��
        UpdateProjectilSprite(); 
        _trailRenderer.Clear();
        _currentDuration = 0;
        _spriteRenderer.color = attackData.projectileColor;

        transform.right = _direction;

        _isReady = true;
    }

    private void UpdateProjectilSprite()
    {
        // ����ü�� ũ�� ����
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        //�ı��� ȿ��
        if (createFx)
        {
            // ��ƼŬ 
        }
        gameObject.SetActive(false); 
    }
}