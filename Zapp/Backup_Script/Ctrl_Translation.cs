using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTranslateWithCollider : MonoBehaviour
{
    private bool isObjectSelected = false;
    private Vector2 touchStart;
    public float translationSpeed = 0.007f;

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
                        isObjectSelected = true;
                        touchStart = touch.position;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isObjectSelected)
            {
                float swipeValueX = touch.position.x - touchStart.x;
                float swipeValueY = touch.position.y - touchStart.y;

                float translationX = swipeValueX * translationSpeed * Time.deltaTime;
                float translationY = swipeValueY * translationSpeed * Time.deltaTime;

                transform.Translate(-translationY, translationX, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isObjectSelected = false;
            }
        }
    }
}
