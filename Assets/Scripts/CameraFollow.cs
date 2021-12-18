using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTarget;
    [SerializeField] private Vector3 offset;
    private Vector3 cameraVelocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.3f;

    private void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - cameraTarget.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;
        transform.position = Vector3.SmoothDamp(
            transform.position, targetPosition, ref cameraVelocity, smoothTime
        );
        
        transform.LookAt(cameraTarget);
    }
}
