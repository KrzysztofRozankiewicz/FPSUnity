using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFace : MonoBehaviour
{
    Vector3 direction;

    void Update()
    {
        direction = Camera.main.transform.forward;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
