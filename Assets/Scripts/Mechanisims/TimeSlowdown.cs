using System;
using UnityEngine;
using TMPro;
public class TimeSlowdown : MonoBehaviour
{
    [SerializeField] private TMP_Text timeLeft;
    [SerializeField] public int timeRemaining = 10;
    public int stableTimeRemaining;
    private float timer;
    public bool isTimeSlow = false;
    private float slowdownFactor = 0.2f;
    private float slowdownLength = 0f;

    void Start()
    {
        stableTimeRemaining = timeRemaining;
    }
    void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
           
    }

    private void Update()
    {
        SlowDownTimer();

        if (Input.GetKeyDown(KeyCode.T))
        {
            isTimeSlow = !isTimeSlow;
            if (isTimeSlow)
            {
                DoSlowmotion();
            }
            else
            {
                Time.timeScale = 1;
            }

        }
    }

    private void SlowDownTimer()
    {
        timeLeft.text = "SlowTime: " + timeRemaining;
        
        if (isTimeSlow)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= 1)
            {
                timeRemaining -= 1;
                timer = 0;
            }

            if (timeRemaining == 0)
            {
                timer = 0;
                isTimeSlow = false;
                Time.timeScale = 1;
            }
            timeLeft.text = "SlowTime: " + timeRemaining;
        }
        
    }
}


