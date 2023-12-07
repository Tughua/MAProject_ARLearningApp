using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider uiSlider;
    public float touchHoldDuration = 3f;
    public float appearanceDuration = 3f;
    
    private bool sliderVisible;
    private float touchTimer;
    private float appearanceTimer;

    void Start()
    {
        ResetTimers();
        HideSlider();
    }

    void Update()
    {
        CheckTouchHold();

        if (sliderVisible)
        {
            appearanceTimer += Time.deltaTime;

            if (appearanceTimer >= appearanceDuration)
            {
                HideSlider();
                ResetTimers();
            }
        }
    }

    void CheckTouchHold()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchTimer = 0f;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                touchTimer += Time.deltaTime;

                if (touchTimer >= touchHoldDuration)
                {
                    ShowSlider();
                }
            }
        }
    }

    void ShowSlider()
    {
        uiSlider.gameObject.SetActive(true);
        sliderVisible = true;
    }

    void HideSlider()
    {
        uiSlider.gameObject.SetActive(false);
        sliderVisible = false;
    }

    void ResetTimers()
    {
        touchTimer = 0f;
        appearanceTimer = 0f;
    }
}


