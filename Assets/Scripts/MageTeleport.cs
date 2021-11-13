using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTeleport : MonoBehaviour
{
    private Movement movement;
    public bool canFloat;
    public float distance = 4f;
    public float floatSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }

        if (movement.grounded && Input.GetKeyDown(KeyCode.Space))
        {
            print("yo float should be true now");
            canFloat = true;
        }

        if (canFloat && !movement.grounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement.rb.velocity = new Vector3(movement.rb.velocity.x, -floatSpeed, movement.rb.velocity.z);
            }
        }
    }
}
