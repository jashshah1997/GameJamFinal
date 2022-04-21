using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool isAiming;

    public bool inInventory;
    public InventoryComponent inventory;
    public GameUIController uiController;
    public WeaponHolder weaponHolder;
    public HealthComponent healthComponent;

    private void Awake()
    {
        weaponHolder = GetComponent<WeaponHolder>();
        inventory = GetComponent<InventoryComponent>();
        uiController = FindObjectOfType<GameUIController>();
        healthComponent = GetComponent<HealthComponent>();
    }

    public void OnInventory(InputValue value)
    {
        if (inInventory)
        {
            inInventory = false;
        }
        else
        {
            inInventory = true;
        }

        OpenInventory(inInventory);
    }

    private void OpenInventory(bool open)
    {
        if (open)
        {
            AppEvents.InvokeMouseCursorEnable(true);
            uiController.EnableInventoryMenu();
        }
        else
        {
            AppEvents.InvokeMouseCursorEnable(false);
            uiController.EnableGameMenu();
        }
    }
}