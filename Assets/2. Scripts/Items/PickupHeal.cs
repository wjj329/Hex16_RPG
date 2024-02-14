using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHeal : PickupItem
{
    [SerializeField] int healValue = 10;
    //private HealthSystem healthSystem;

    protected override void OnPickedUp(GameObject receiver)
    {
        //_healthSystem = receiver.GetComponent<HealthSystem>();
        //_healthSystem.ChangeHealth(healValue);
    }

}
