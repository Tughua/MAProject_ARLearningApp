using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedTimerSlider : MonoBehaviour 
{
    public float timerDuration = 30f;
    public Slider timerSlider;

    private float timer;

    void Start()
    {
        timer = timerDuration;
    }

    void Update() 
    {
        timer -= Time.deltaTime;

        // Animate timer from 1 to 0 
        float normalizedTime = Mathf.Clamp01(timer / timerDuration);

        // Update slider
        timerSlider.value = normalizedTime;

        if(timer <= 0) {
            // Reset the timer to its initial duration when it reaches 0
            timer = timerDuration;
        }
    }
}
