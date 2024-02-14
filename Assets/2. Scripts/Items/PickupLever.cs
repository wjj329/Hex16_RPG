using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLever : PickupItem
{
    public string targetTag = "Monster";


    protected override void OnPickedUp(GameObject receiver)
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        // 찾은 모든 GameObject를 순회하며 태그가 일치하는 경우 삭제합니다.
        foreach (GameObject obj in allObjects)
        {

            if (obj.CompareTag(targetTag))
            {
                Destroy(obj);
            }
        }
    }

}
