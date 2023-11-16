using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSwipping : MonoBehaviour
{
    private Touch touch;

    private Vector2 touchPosition;

    private Quaternion rotationX;

    private float rotateSpeedModifier = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotationX = Quaternion.Euler(
                    0f,
                     touch.deltaPosition.y * rotateSpeedModifier,
                    0f);

                    transform.rotation = rotationX * transform.rotation;
            }
        }
    }
}
