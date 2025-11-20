using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody rb;
    [SerializeField] private Transform sphere;  
    [SerializeField] private float speed = 10f;
    private Vector3 moveDirection;

    private Vector3 targetPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        targetPosition = new Vector3(sphere.position.x, transform.position.y, sphere.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        moveDirection = new Vector3(input.x, 0f, input.y).normalized * moveSpeed;
    }
    private void FixedUpdate()
    {
        // Apply movement while keeping Rigidbody physics (gravity still works)
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }
}
