using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 1)]
public class ConsumableScriptable : ItemScript
{
    public int effect = 0;


    public override void UseItem(PlayerController playerController)
    {
        // TODO: check to see if player is at max HP

        SetAmount(amountValue - 1);

        if (amountValue <= 0)
        {
            DeleteItem(playerController);
        }

    }
}