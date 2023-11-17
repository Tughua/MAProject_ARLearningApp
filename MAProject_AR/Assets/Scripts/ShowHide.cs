using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapToggle : MonoBehaviour
{
    private float lastTapTime;
    public float doubleTapTimeThreshold = 0.5f; // Adjust this value as needed
    public GameObject targetObject; // Assign the GameObject you want to toggle in the Inspector

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                if (Time.time - lastTapTime < doubleTapTimeThreshold)
                {
                    ToggleVisibility();
                }

                lastTapTime = Time.time;
            }
        }
    }

    void ToggleVisibility()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
