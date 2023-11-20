using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility2 : MonoBehaviour
{
    public GameObject targetObject; // Assign your GameObject to this field
    public float holdTime = 2f; // Adjust this value for the hold time required

    private float touchStartTime;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time; // Record the start time when touch begins
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                float touchDuration = Time.time - touchStartTime;

                // Check if the touch duration is greater than the hold time
                if (touchDuration >= holdTime)
                {
                    ToggleObjectVisibility();
                }
            }
        }
    }

    void ToggleObjectVisibility()
    {
        if (targetObject != null)
        {
            // Toggle the visibility by setting the opposite of the current state
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
