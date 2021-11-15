using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Variables variables;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            variables.checkpoint = transform.position;
        }
    }
}
