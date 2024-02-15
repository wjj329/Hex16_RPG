using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Color hitColor = new Color(1.0f, 0.8f, 0.8f); // �ǰ� �÷�
    public float hitEffectDuration = 0.04f; // �ǰ� ȿ�� ���� �ð�

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isHit = false;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }


    public void ApplyHitEffect()  // �ǰ� ȿ���� ����
    {
        if (!isHit)
        {
            spriteRenderer.color = hitColor;
            isHit = true;
            Invoke("RemoveHitEffect", hitEffectDuration);
        }
    }


    private void RemoveHitEffect() // �ǰ� ȿ�� ����
    {
        spriteRenderer.color = originalColor;
        isHit = false;
    }
}