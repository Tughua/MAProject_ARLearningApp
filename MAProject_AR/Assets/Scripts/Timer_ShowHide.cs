using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCanvasController : MonoBehaviour
{
    public GameObject infoCanvas; // Reference to your info canvas GameObject

    private bool touchInProgress = false;
    private float touchStartTime;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for touch start
            if (touch.phase == TouchPhase.Began)
            {
                touchInProgress = true;
                touchStartTime = Time.time;
            }

            // Check for touch end
            if (touchInProgress && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            {
                touchInProgress = false;

                // Hide the info canvas if the touch is released
                infoCanvas.SetActive(false);
            }

            // Check if the touch has been held for 2 seconds
            if (touchInProgress && Time.time - touchStartTime >= 0.5f)
            {
                // Display the info canvas after 2 seconds
                infoCanvas.SetActive(true);

                // Check if the canvas has been visible for 2 seconds
                if (Time.time - touchStartTime >= 4f)
                {
                    // Hide the info canvas after an additional 2 seconds
                    infoCanvas.SetActive(false);
                }
            }
        }
    }
}

