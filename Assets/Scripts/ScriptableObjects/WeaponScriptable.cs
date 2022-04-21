using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 2)]
public class WeaponScriptable : EquippableScriptable
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController playerController)
    {
        if (equipped)
        {
            //TODO: unequip from inventory
            //TODO: remove from controller
        }
        else
        {
            //TODO: invoke OnWeaponEquipped 
            //TODO: equip weapon from weapon holder on playercontroller
            playerController.weaponHolder.EquipWeapon(this);
            //PlayerEvents.InvokeOnWeaponEquipped(itemPrefab.GetComponent<WeaponComponent>());
        }

        base.UseItem(playerController);
    }
}