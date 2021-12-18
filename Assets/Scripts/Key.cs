using System;
using UnityEngine;
using UnityEngine.Video;

public class Key : MonoBehaviour
{
    [SerializeField] private Door doorToUnlock;
    [SerializeField] private float keyRotationSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * keyRotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToUnlock.UnlockDoor();
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (doorToUnlock != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, doorToUnlock.transform.position - transform.position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.5f);
        }
    }
}
