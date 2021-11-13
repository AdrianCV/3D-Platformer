using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSprint : MonoBehaviour
{
    private Movement movement;
    private bool hasDoubleJumped;
    public float sprintSpeed;
    private float defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        defaultSpeed = movement.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.grounded && Input.GetKey(KeyCode.LeftShift))
        {
            movement.speed = sprintSpeed;
        }
        else
        {
            movement.speed = defaultSpeed;
        }

        if (movement.grounded)
        {
            hasDoubleJumped = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !movement.grounded && !hasDoubleJumped)
        {
            movement.rb.velocity = new Vector3(movement.rb.velocity.x, movement.jumpSpeed, movement.rb.velocity.z);
            hasDoubleJumped = true;
        }
    }
}
