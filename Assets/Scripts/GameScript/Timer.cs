using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Represents a timer in the game.
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] private float timeValue = 180f;
    [SerializeField] private TextMeshProUGUI timeText;

    /// <summary>
    /// Updates the timer each frame.
    /// Decreases the time value and loads the win screen when the time runs out.
    /// </summary>
    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            SceneManager.LoadScene("WinScreen");
        }

        DisplayTime(timeValue);
    }

    /// <summary>
    /// Displays the remaining time on the UI.
    /// </summary>
    /// <param name="timeToDisplay">The time to display.</param>
    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Time Remaining \n {0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// Adds additional time to the timer.
    /// </summary>
    public void AddTime()
    {
        timeValue++;
    }
}