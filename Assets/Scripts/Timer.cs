using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [ SerializeField ] TextMeshProUGUI timerText;
    private float remainingTime = 30.0f;
    public float RemainingTime => remainingTime; //property

    public int minutes;
    public int seconds;

    public PlayerController player;

    void Update()
    {
        remainingTime -= Time.deltaTime;
        minutes = Mathf.FloorToInt(remainingTime / 60);
        seconds =  Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}" , minutes , seconds);

        loseCondition();
        winCondition();
    }
    
    public void loseCondition()
    {
        if( minutes == 0.0f && seconds == 0.0f )
        {
            timerText.text = "lose";
        }
    }

    private void winCondition()
    {
        if( player.SatietyPoints >= 100 )
        {
            timerText.text = "win";
        }
    }
}
