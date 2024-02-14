using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAnimations : MonoBehaviour
{
    protected Animator animator; // Animator ������Ʈ ����
    protected CharacterController controller; // CharacterController ������Ʈ ����

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>(); // �ڽ� ������Ʈ �� Animator ������Ʈ ����
        controller = GetComponent<CharacterController>(); // CharacterController ������Ʈ�� ã�� ����
    }
}
