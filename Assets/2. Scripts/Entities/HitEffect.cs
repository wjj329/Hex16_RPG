using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Color hitColor = new Color(1.0f, 0.8f, 0.8f); // 피격 컬러
    public float hitEffectDuration = 0.04f; // 피격 효과 지속 시간

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isHit = false;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }


    public void ApplyHitEffect()  // 피격 효과를 적용
    {
        if (!isHit)
        {
            spriteRenderer.color = hitColor;
            isHit = true;
            Invoke("RemoveHitEffect", hitEffectDuration);
        }
    }


    private void RemoveHitEffect() // 피격 효과 해제
    {
        spriteRenderer.color = originalColor;
        isHit = false;
    }
}