using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEyeLook : MonoBehaviour
{
    public Transform eyeDest;
    public Camera mainCamera;
    public float DistanceFromCamera = 4f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = DistanceFromCamera;

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        eyeDest.position = worldPos;
    }
}