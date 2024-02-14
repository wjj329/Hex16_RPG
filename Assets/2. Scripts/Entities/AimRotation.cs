using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponRenderer; // weapon sprite ������(����Ƽ)
    [SerializeField] private Transform weaponPivot; // weapon pivot ������(����Ƽ)
    [SerializeField] private SpriteRenderer characterRenderer; // ĳ���� sprite ������(����Ƽ)

    private CharacterController _controller; // OnLookEvent �̺�Ʈ ������

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        // ���� ������Ʈ���� CharacterController ������Ʈ ����
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
        // OnLookEvent �̺�Ʈ�� ����
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateWeapon(newAimDirection); // ���� �������� weaponPivotȸ�� 
    }

    private void RotateWeapon(Vector2 direction) // weaponPivotȸ�� ����
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // y, x ������ Atan2�� �̿��� ȸ�� ������ ���� + ���ȿ��� degree(��)�� ��ȯ
        // z�� �������� ȸ�� 

        weaponRenderer.flipY = Mathf.Abs(rotZ) > 90f; 
        // 1.  rotZ > 90���� weapon sprite y�� filp

        characterRenderer.flipX = weaponRenderer.flipY; 
        // 2. ĳ���� sprite�� x�� => weapon sprite�� y��� �����Ͽ� filp��

        weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        // 3. rotZ ���� weapon pivot ȸ�� 
    }
}
