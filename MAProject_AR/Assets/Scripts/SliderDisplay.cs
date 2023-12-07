using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility3 : MonoBehaviour
{
    public GameObject targetObject; // Assign your GameObject to this field
    public float requiredHoldTime = 4f; // Adjust this value for the required hold time

    private float touchStartTime;
    private bool objectVisible;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time; // Record the start time when touch begins
                objectVisible = false;
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                float touchDuration = Time.time - touchStartTime;

                // Check if the touch duration is greater than or equal to the required hold time
                if (touchDuration >= requiredHoldTime && !objectVisible)
                {
                    ShowObject();
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                HideObject();
            }
        }
    }

    void ShowObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
            objectVisible = true;
        }
    }

    void HideObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
            objectVisible = false;
        }
    }
}






