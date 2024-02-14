using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player; // 플레이어 오브젝트 참조

    private void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        
        // Vector3.Lerp -> 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}