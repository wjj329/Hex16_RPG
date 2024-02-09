using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y).normalized * speed * Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x > Screen.width/2)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        Debug.Log($"{new Vector2(x, y).normalized}");
    }
}