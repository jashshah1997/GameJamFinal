using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine.Editor;

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
    
    private GameObject m_pausePanel;

    private void Awake()
    {
        weaponHolder = GetComponent<WeaponHolder>();
        inventory = GetComponent<InventoryComponent>();
        uiController = FindObjectOfType<GameUIController>();
        healthComponent = GetComponent<HealthComponent>();
        m_pausePanel = GameObject.Find("PausePanel");
        m_pausePanel.SetActive(false);
    }
    public void OnPause()
    {
        Time.timeScale = 0;
        m_pausePanel.SetActive(true);
        AppEvents.InvokeMouseCursorEnable(true);
        PauseActionMap();
        m_pausePanel.GetComponent<PauseMenuController>().SetPauseMenu();
    }

    public void OnEndGame(int score)
    {
        Time.timeScale = 0;
        m_pausePanel.SetActive(true);
        AppEvents.InvokeMouseCursorEnable(true);
        PauseActionMap();
        m_pausePanel.GetComponent<PauseMenuController>().SetLevelFinished(score);
    }

    public void GameActionMap()
    {
        GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerActionMap");
    }

    public void PauseActionMap()
    {
        GetComponent<PlayerInput>().SwitchCurrentActionMap("PauseActionMap");
    }

    public void OnInventory(InputValue value)
    {
        // Do nothing
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