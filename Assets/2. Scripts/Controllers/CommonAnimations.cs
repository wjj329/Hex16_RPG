using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAnimations : MonoBehaviour
{
    protected Animator animator; // Animator 컴포넌트 참조
    protected CharacterController controller; // CharacterController 컴포넌트 참조

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>(); // 자식 오브젝트 중 Animator 컴포넌트 참조
        controller = GetComponent<CharacterController>(); // CharacterController 컴포넌트를 찾아 참조
    }
}
