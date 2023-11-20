using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing2 : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back,
                                Camera.main.transform.rotation * Vector3.down);
    }
}
