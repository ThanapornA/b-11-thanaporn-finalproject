using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [ SerializeField ] TextMeshProUGUI timerText;
    private float remainingTime = 60.0f;
    public float RemainingTime => remainingTime; //property

    public int minutes;
    public int seconds;

    public PlayerController player;

    public GameOverScreen GameOverScreen;

    void Update()
    {
        remainingTime -= Time.deltaTime;
        minutes = Mathf.FloorToInt(remainingTime / 60);
        seconds =  Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}" , minutes , seconds);

        loseCondition();
        winCondition();
    }
    
    //game end conditions
    public void loseCondition()
    {
        if( minutes == 0.0f && seconds == 0.0f )
        {
            timerText.text = "time's up!";
            //set gameover screen active
            GameOverScreen.TimesUpScreen();
            GameOverScreen.gameObject.SetActive(true);
        }
    }

    private void winCondition()
    {
        if( player.SatietyPoints >= 100 )
        {
            timerText.text = "you're full! you win";
            //set gameover screen active
            GameOverScreen.WinScreen();
            GameOverScreen.gameObject.SetActive(true);
        }
    }
}
