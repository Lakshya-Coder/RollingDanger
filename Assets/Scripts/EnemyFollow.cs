using System;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float spped = 1f;
    private Rigidbody rb;
    private bool isPlayerInRange = false;
    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }    
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInRange)
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            rb.AddForce(targetDirection * spped * Time.fixedDeltaTime, ForceMode.VelocityChange);

            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0;

            rb.velocity = newVelocity; 
        }
    }
}
