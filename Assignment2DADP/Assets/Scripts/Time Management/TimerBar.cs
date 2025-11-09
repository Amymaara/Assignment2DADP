using Ink.Runtime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour

// Title: Simple Countdown Timer with Circular Progressbar [ Unity Tutorial ]
// Author: Game Dev Box
// Date Accessed: 26 October 2025
// Accessibility: https://www.youtube.com/watch?v=2gPHkaPGbpI


{
    [Header("UI")]
    [SerializeField] private Image timerBar;

    [Header("Settings")]
    public int timerDuration;

    public int totalCustomers = 0;
    private int customersServed;

    private int remainingDuration;
    private bool timerRunning;
    private bool timerStarted;

    public event System.Action<bool> OnDayFinished;

    [Header("Bed")]
    public BedTrigger bed;

    public void StartTimer()
    {
        if (timerStarted) return;
        timerStarted = true;

        remainingDuration = timerDuration;
        timerRunning = true;

        StartCoroutine(UpdateTimer());
    }

    public void SetTotalCustomers(int total)
    {
        totalCustomers = total;
    }

    public void CustomerServed()
    {
        customersServed++;

        if (customersServed >= totalCustomers && timerRunning)
        {
            timerRunning = false;
            StopAllCoroutines();
            OnEnd(true);
        }
    }
    IEnumerator UpdateTimer()
    {
        while (timerRunning && remainingDuration >= 0)
        {
            timerBar.fillAmount = Mathf.InverseLerp(0, timerDuration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        if (timerRunning) OnEnd(false);
    }

    void OnEnd(bool winSuccess)
    {
        timerRunning = false;

        bool success = winSuccess || (customersServed >= totalCustomers);

        if (success)
        {
            Debug.Log("all customer served - success");
            bed.canInteract = true;
            OnDayFinished?.Invoke(true);
        }
        else
        {
            Debug.Log("customers still waiting - fail");
            OnDayFinished?.Invoke(false);
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
