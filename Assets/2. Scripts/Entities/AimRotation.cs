using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponRenderer; // weapon sprite 지정용(유니티)
    [SerializeField] private Transform weaponPivot; // weapon pivot 지정용(유니티)
    [SerializeField] private SpriteRenderer characterRenderer; // 캐릭터 sprite 지정용(유니티)

    private CharacterController _controller; // OnLookEvent 이벤트 구독용

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        // 게임 오브젝트에서 CharacterController 컴포넌트 참조
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
        // OnLookEvent 이벤트와 연결
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateWeapon(newAimDirection); // 조준 방향으로 weaponPivot회전 
    }

    private void RotateWeapon(Vector2 direction) // weaponPivot회전 로직
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // y, x 방향의 Atan2를 이용해 회전 각도를 구함 + 라디안에서 degree(도)로 변환
        // z축 기준으로 회전 

        weaponRenderer.flipY = Mathf.Abs(rotZ) > 90f; 
        // 1.  rotZ > 90도면 weapon sprite y축 filp

        characterRenderer.flipX = weaponRenderer.flipY; 
        // 2. 캐릭터 sprite의 x축 => weapon sprite의 y축과 연동하여 filp됨

        weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        // 3. rotZ 따라 weapon pivot 회전 
    }
}
