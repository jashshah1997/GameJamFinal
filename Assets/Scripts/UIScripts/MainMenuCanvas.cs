using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    private GameObject m_startPanel;
    private GameObject m_instructionsPanel;
    private GameObject m_creditsPanel;

    private void Awake()
    {
        m_startPanel = GameObject.Find("StartPanel");
        m_instructionsPanel = GameObject.Find("InstructionsPanel");
        m_creditsPanel = GameObject.Find("CreditsPanel");
        m_instructionsPanel.SetActive(false);
        m_creditsPanel.SetActive(false);
    }

    public void LoadGameScene()
    {
        Debug.Log("asd");
        SceneManager.LoadScene("GameScene");
    }

    public void ToggleInstructions(bool value)
    {
        m_startPanel.SetActive(!value);
        m_instructionsPanel.SetActive(value);
    }

    public void ToggleCredits(bool value)
    {
        m_startPanel.SetActive(!value);
        m_creditsPanel.SetActive(value);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}