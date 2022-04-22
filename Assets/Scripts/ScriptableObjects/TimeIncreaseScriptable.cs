using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeIncrease", menuName = "Items/TimeIncrease", order = 1)]
public class TimeIncreaseScriptable : ItemScript
{
    public int effect = 0;


    public override void UseItem(PlayerController playerController)
    {
        Debug.Log("Use timeincrease");
    }

    public override void OnPickupItem(PlayerController playerController)
    {
        GameManager.instance.AddRemainingTime(effect);
    }
}