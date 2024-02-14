using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    private Camera _camera;
    protected override void Awake()
    {
        base.Awake(); 
        _camera = Camera.main; // 메인 카메라 참조
    }

    public void OnMove(InputValue value) // 플레이어 움직임 입력
    {
        Vector2 moveInput = value.Get<Vector2>().normalized; // 입력값을 vector2로 변환 + 정규화
        CallMoveEvent(moveInput); // 변환된 입력값 CallMoveEvent 이벤트에 전달
    }

    public void OnLook(InputValue value) // 플레이어 마우스 입력 
    { 
        Vector2 newAim = value.Get<Vector2>(); // 마우스 입력값
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim); // (마우스 커서)스크린 좌표 -> 월드 좌표
        newAim = (worldPos - (Vector2)transform.position).normalized;
        // 플레이어 위치 기준으로 방향 구함

        if (newAim.magnitude >= .9f)
        // Vector 값을 실수로 변환 => 마우스 인식 민감도 낮춤
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value) // 플레이어 발사 입력
    {
        IsAttacking = value.isPressed; // 발사 버튼 눌리면 호출
    }
}


