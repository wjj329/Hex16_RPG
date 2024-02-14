using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLever : PickupItem
{
    public string targetTag = "Monster";


    protected override void OnPickedUp(GameObject receiver)
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        // ã�� ��� GameObject�� ��ȸ�ϸ� �±װ� ��ġ�ϴ� ��� �����մϴ�.
        foreach (GameObject obj in allObjects)
        {

            if (obj.CompareTag(targetTag))
            {
                Destroy(obj);
            }
        }
    }

}
