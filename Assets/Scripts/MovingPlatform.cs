using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float offset = 10, speed;
    private Vector3 pos1Sideways, pos2Sideways, pos1Up, pos2Up;
    private bool moveToPos1, moveToPos2;
    public bool moveUp, moveSideways;
    // Start is called before the first frame update
    void Start()
    {
        pos1Sideways = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        pos2Sideways = new Vector3(transform.position.x, transform.position.y, transform.position.z - offset);
        pos1Up = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        pos2Up = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
        moveToPos2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSideways)
        {
            if (Vector3.Distance(transform.position, pos1Sideways) < 1 && moveToPos1)
            {
                moveToPos2 = true;
                moveToPos1 = false;
            }

            if (Vector3.Distance(transform.position, pos2Sideways) < 1 && moveToPos2)
            {
                moveToPos1 = true;
                moveToPos2 = false;
            }

            if (moveToPos1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1Sideways, speed * Time.deltaTime);
            }
            else if (moveToPos2)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2Sideways, speed * Time.deltaTime);
            }
        }
        else if (moveUp)
        {
            if (Vector3.Distance(transform.position, pos1Up) < 1 && moveToPos1)
            {
                moveToPos2 = true;
                moveToPos1 = false;
            }

            if (Vector3.Distance(transform.position, pos2Up) < 1 && moveToPos2)
            {
                moveToPos1 = true;
                moveToPos2 = false;
            }

            if (moveToPos1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos1Up, speed * Time.deltaTime);
            }
            else if (moveToPos2)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos2Up, speed * Time.deltaTime);
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.SetParent(gameObject.transform, true);
    }

    private void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.parent = null;
    }
}
