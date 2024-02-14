using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _contoller; // CharacterController����

    [SerializeField] private Transform BulletSpawnPosition; // źȯ ���� ��ġ ������ (����Ƽ)
    
    public GameObject BulletPrefab; // źȯ ������ ������ (����Ƽ)

    private Vector2 _aimDirection = Vector2.right; // �⺻ ���� ����

    private void Awake()
    {
        _contoller = GetComponent<CharacterController>(); // CharacterController ������Ʈ�� ������ ����
    }

    void Start()
    {
        //_contoller.OnAttackEvent += OnShoot; // OnAttackEvent�� OnShoot �޼ҵ� ����
        _contoller.OnLookEvent += OnAim; // OnLookEvent �̺�Ʈ�� OnAim �޼ҵ� ����
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection; // ���� ���� ������Ʈ
    }

    private void OnShoot()
    {
        CreateProjectile(); // źȯ ���� �޼��� ȣ��
    }

    private void CreateProjectile() // źȯ(������) ����
    {
        Instantiate(BulletPrefab, BulletSpawnPosition.position, Quaternion.identity); // �������� ������� �߻�ü�� �����մϴ�.
    }
}

