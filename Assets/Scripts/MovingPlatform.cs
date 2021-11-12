using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float offset = 10, speed;
    private Vector3 pos1, pos2;
    private bool moveToPos1, moveToPos2;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        pos2 = new Vector3(transform.position.x, transform.position.y, transform.position.z - offset);
        moveToPos2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, pos1) < 1 && moveToPos1)
        {
            moveToPos2 = true;
            moveToPos1 = false;
        }

        if (Vector3.Distance(transform.position, pos2) < 1 && moveToPos2)
        {
            moveToPos1 = true;
            moveToPos2 = false;
        }

        if (moveToPos1)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
        }
        else if (moveToPos2)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
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
