using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    public SpriteRenderer armRenderer;
    public Transform armPivot;

    public SpriteRenderer characterRenderer;

    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        RotateArm(mousePos);
    }

    public void RotateArm(Vector3 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
