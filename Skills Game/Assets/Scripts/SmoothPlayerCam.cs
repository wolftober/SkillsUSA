using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPlayerCam : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 2f;
    public Vector3 offset;

    void Update()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }
}
