using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Properties
    private Rigidbody rb;
    private float hozInput, vertInput;
    [SerializeField] private float speed = 10f;
    private bool isJumpButtonPressed;
    [SerializeField] private float jumpForce = 10;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // d -> 1.0f a -> -1.0f
        hozInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpButtonPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(hozInput, 0, vertInput);
        playerMovement *= speed;
        rb.AddForce(playerMovement, ForceMode.Acceleration);

        Ray ray = new Ray(transform.position, Vector3.down);

        // 1 / 2 + 0.01 = 0.51
        if (Physics.Raycast(ray, transform.localScale.x / 2f + 0.01f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isJumpButtonPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumpButtonPressed = false;
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     isGrounded = true;
    // }
    //
    // private void OnCollisionExit(Collision other)
    // {
    //     isGrounded = false;
    // }
}
