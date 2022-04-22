using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private Button m_resumeButton;
    private Button m_backToMainMenuButton;

    private TextMeshProUGUI m_titleText;
    private TextMeshProUGUI m_scoreText;

    private int m_nextLevelId = 1;

    // Start is called before the first frame update
    void Awake()
    {
        m_resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        m_resumeButton.onClick.AddListener(onResumeButtonClicked);

        m_backToMainMenuButton = GameObject.Find("BackToMainMenuButton").GetComponent<Button>();
        m_backToMainMenuButton.onClick.AddListener(onBackToMainMenuClicked);

        m_titleText = GameObject.Find("TitleText").GetComponent<TextMeshProUGUI>();
        m_scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

 
    public void SetPauseMenu()
    {
        m_titleText.text = "Pause Menu";
        m_resumeButton.gameObject.SetActive(true);
    }

    public void SetLevelFinished(int score)
    {
        m_titleText.text = "Level Finished";
        m_scoreText.text = "Zombies shot: " + score;
        m_resumeButton.gameObject.SetActive(false);
    }

    private void onResumeButtonClicked()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GameObject.FindObjectOfType<PlayerController>().GameActionMap();
        AppEvents.InvokeMouseCursorEnable(false);
    }

    private void onBackToMainMenuClicked()
    {
        Time.timeScale = 1;
        AppEvents.InvokeMouseCursorEnable(true);
        SceneManager.LoadScene("MainMenuScene");
    }

}

