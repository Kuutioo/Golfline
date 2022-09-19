using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;

    [Header("Values")]
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float mouseSensitivity = 3.0f;
    [SerializeField] private float distanceFromTarget = 5.0f;
    [SerializeField] private float clampRotationX = 5;
    [SerializeField] private float clampRotationY = 40;

    private float rotationY;
    private float rotationX = 20f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;
    

    private void Awake()
    {
        transform.position = target.position - transform.forward * distanceFromTarget;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationY += mouseX;
            rotationX -= mouseY;

            rotationX = Mathf.Clamp(rotationX, clampRotationX, clampRotationY);

            Vector3 nextRotation = new Vector3(rotationX, rotationY);
            currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);

            transform.localEulerAngles = currentRotation;

            transform.position = target.position - transform.forward * distanceFromTarget;
        }
    }
}
