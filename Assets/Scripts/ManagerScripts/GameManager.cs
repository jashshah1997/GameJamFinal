using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public bool cursorActive = true;
    private TextMeshProUGUI m_timerText;
    private float m_currentTime;
    private int m_zombiesShot;
    private bool m_gameOver;

    protected override void Awake()
    {
        m_timerText = GameObject.Find("CurrentTimerText").GetComponent<TextMeshProUGUI>();
        m_currentTime = 10.5f;
        m_zombiesShot = 0;
        m_gameOver = false;
    }

    public void Update()
    {
        if (m_gameOver) return;

        if (m_currentTime < 0.1)
        {
            GameObject.Find("James").GetComponent<PlayerController>().OnEndGame(m_zombiesShot);
            m_gameOver = true;
            return;
        }

        m_currentTime -= Time.deltaTime;
        m_timerText.text = (int)m_currentTime + " s";
    }

    public void AddZombieCount()
    {
        m_zombiesShot++;
    }

    public void AddRemainingTime(int value)
    {
        m_currentTime += value;
    }

    void EnableCursor(bool enable)
    {
        if (enable)
        {
            cursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            cursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnEnable()
    {
        AppEvents.MouseCursorEnabled += EnableCursor;
    }

    private void OnDisable()
    {
        AppEvents.MouseCursorEnabled -= EnableCursor;
    }
}