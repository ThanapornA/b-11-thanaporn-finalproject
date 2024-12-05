using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI summaryText; //Game Over or Win
    public TextMeshProUGUI showConditionText; //when game ends show the explanation

    private bool isPaused;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void TimesUpScreen()
    {
        summaryText.text = "Game Over";
        showConditionText.text = "time's up!";
        PauseGame();
    }
    
    public void TriggeredEneScreen()
    {
        summaryText.text = "Game Over";
        showConditionText.text = "you triggered the seal and got eaten!";
        PauseGame();
    }

    public void WinScreen()
    {
        summaryText.text = "Win";
        showConditionText.text = "you're full!";
        PauseGame();
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene("SampleScene");
        ResumeGame();
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
