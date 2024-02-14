using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStatModifiers : PickupItem
{
    //[SerializeField] private List<CharacterStats> statsModifier;
    protected override void OnPickedUp(GameObject receiver)
    {
        //CharacterStatsHandler statsHandler = receiver.GetComponent<CharacterStatsHandler>();
        //foreach(CharacterStats stat in statsModifier)
        //{
        //    statsHandler.AddStatModifier(stat);
        //}
    }


}
