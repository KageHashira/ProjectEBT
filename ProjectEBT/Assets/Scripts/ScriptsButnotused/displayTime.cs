using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayTime : MonoBehaviour
{
    public TMP_InputField minutesInput;
    public TMP_Text timerText;
    public Button resetButton;

    public float startTime;
    public float timeInMinutes;
    public bool timerStarted;

    private void Start()
    {
        resetButton.onClick.AddListener(ResetTimer);
        timerText.text = "00:00";
    }

    private void Update()
    {
        if (timerStarted)
        {
            UpdateTimer();
        }
    }

    public void StartTimer()
    {
        if (float.TryParse(minutesInput.text, out timeInMinutes) && timeInMinutes > 0)
        {
            startTime = Time.time;
            timerStarted = true;
            minutesInput.interactable = false;
        }
    }

    public void UpdateTimer()
    {
        float elapsedTime = Time.time - startTime;
        float remainingTime = timeInMinutes * 60 - elapsedTime;

        if (remainingTime > 0)
        {
            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "Time's up!";
        }
    }

    private void ResetTimer()
    {
        timerStarted = false;
        minutesInput.interactable = true;
        timerText.text = "00:00";
    }
}
