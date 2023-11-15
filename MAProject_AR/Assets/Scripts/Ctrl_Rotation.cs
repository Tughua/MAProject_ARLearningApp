using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotate : MonoBehaviour
{
    private Vector2 touchStart;
    private float rotationSpeed = 0.5f; // Adjust this value for rotation speed

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float swipeValue;

                // Check if the phone is held horizontally or vertically
                if (Screen.width > Screen.height)
                {
                    // Phone is held horizontally
                    swipeValue = touch.position.x - touchStart.x;
                }
                else
                {
                    // Phone is held vertically
                    swipeValue = touch.position.y - touchStart.y;
                }

                // Adjust the rotation based on the swipe value along the Y-axis
                float rotation = swipeValue * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, rotation, 0);
            }
        }
    }
}


