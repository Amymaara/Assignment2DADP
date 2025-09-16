using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // https://www.youtube.com/watch?v=S12x7txHS1c


    public Slider TimerSlider;
    public float gameTime;
    private bool stopTimer;
    private float remainingTime;

    private void OnEnable()
    {
        stopTimer = false;
        remainingTime = gameTime;                
        TimerSlider.maxValue = gameTime;
        TimerSlider.value = gameTime;
    }

    private void Update()
    {
        if (stopTimer) return;

        remainingTime -= Time.deltaTime;          
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            stopTimer = true;
        }

        TimerSlider.value = remainingTime;
    }
}