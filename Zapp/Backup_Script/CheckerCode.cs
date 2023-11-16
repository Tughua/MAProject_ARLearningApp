using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTranslateRotate : MonoBehaviour
{
    private bool isObjectTranslating = false;
    private Vector2 touchStart;
    private float translationSpeed = 0.004f;
    private float rotationSpeed = 0.5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == GetComponent<BoxCollider>())
                    {
                        isObjectTranslating = true;
                        touchStart = touch.position;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isObjectTranslating)
            {
                float swipeValueX = touch.position.x - touchStart.x;
                float swipeValueY = touch.position.y - touchStart.y;

                float translationX = swipeValueX * translationSpeed * Time.deltaTime;
                float translationY = swipeValueY * translationSpeed * Time.deltaTime;

                transform.Translate(translationX, translationY, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isObjectTranslating = false;
            }
        }

        // Allow rotation if the object is not translating
        if (!isObjectTranslating)
        {
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    float rotation = (touch1.deltaPosition.x + touch2.deltaPosition.x) * rotationSpeed * Time.deltaTime;
                    transform.Rotate(0, rotation, 0);
                }
            }
        }
    }
}