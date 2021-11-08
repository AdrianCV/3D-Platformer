using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private bool grounded;
    public bool canMove;
    private float lookSensitivity = 100f;
    private float xAxisClampDegrees = 45f;
    public float xRotation;
    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
            Jump();
            RotatePlayerAndCamera();
        }
    }

    void Move()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * speed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
    }

    void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1.2f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
    }

    void RotatePlayerAndCamera()
    {
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        float mouseX = playerMouseInput.y * lookSensitivity * Time.deltaTime;
        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -xAxisClampDegrees, xAxisClampDegrees);
        transform.Rotate(0f, playerMouseInput.x * 2, 0f);
        cameraTransform.LookAt(transform);
        Vector3 eulerAngles = cameraTransform.rotation.eulerAngles;
        cameraTransform.rotation = Quaternion.Euler(xRotation, eulerAngles.y, 0);
    }
}
