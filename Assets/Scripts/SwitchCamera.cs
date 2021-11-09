using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // public Transform firstPlayerCamera, secondPlayerCamera, firstPlayer, secondPlayer;
    // public Vector3 firstPlayerCameraRotation, secondPlayerCameraRotation;
    // private float current, target, currentRot, targetRot;
    // private Transform lastTransform, lastPlayer;
    // private Vector3 currentPos, targetPos;

    public Movement playerOneMovement, playerTwoMovement;
    public float speed;
    public Vector3 offset;
    private Transform playerPosition;
    public Transform playerOneTransform, playerTwoTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = playerOneTransform;
        // target = 0;
        // lastTransform = firstPlayer;
        // lastPlayer = firstPlayer;
        // firstPlayerCameraRotation = transform.rotation.eulerAngles;
        // secondPlayerCameraRotation = secondPlayerCamera.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPosition.position + offset, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerPosition = playerPosition == playerOneTransform ? playerTwoTransform : playerOneTransform;
            if (playerPosition == playerOneTransform)
            {
                playerOneMovement.canMove = true;
                playerTwoMovement.canMove = false;
            }
            else if ((playerPosition == playerTwoTransform))
            {
                playerOneMovement.canMove = false;
                playerTwoMovement.canMove = true;
            }
        }
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     target = target == 0 ? 1 : 0;
        //     targetRot = targetRot == 0 ? 1 : 0;
        //     lastTransform = lastTransform == secondPlayerCamera ? firstPlayerCamera : secondPlayerCamera;
        //     lastPlayer = lastPlayer == secondPlayer ? firstPlayer : secondPlayer;
        //     rotateCamera = true;
        //     setXROt = false;
        //     xRotIsSet = false;
        // }

        // if (transform.rotation == lastTransform.rotation && rotateCamera) rotateCamera = false;
        // if (rotateCamera)
        // {
        //     RotateTowardsTarget(lastPlayer.position, transform.position, current);
        // }

        // current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        // transform.position = Vector3.Lerp(firstPlayerCamera.position, secondPlayerCamera.position, current);
        // currentPos = transform.position;

        // if (currentPos == firstPlayerCamera.position)
        // {
        //     secondPlayerMovement.canMove = false;
        //     firstPlayerMovement.canMove = true;
        //     setXROt = true;
        //     if (setXROt && !xRotIsSet)
        //     {
        //         firstPlayerMovement.xRotation = transform.rotation.x;
        //         xRotIsSet = true;
        //     }
        // }
        // else if (currentPos == secondPlayerCamera.position)
        // {
        //     firstPlayerMovement.canMove = false;
        //     secondPlayerMovement.canMove = true;
        //     setXROt = true;
        //     if (setXROt && !xRotIsSet)
        //     {
        //         secondPlayerMovement.xRotation = transform.rotation.x;
        //         xRotIsSet = true;
        //     }
        // }
        // else
        // {
        //     secondPlayerMovement.canMove = false;
        //     firstPlayerMovement.canMove = false;
        // }
    }

    // void RotateTowardsTarget(Vector3 target, Vector3 current, float speed)
    // {
    //     targetPos = target - current;
    //     Quaternion toRotation = Quaternion.LookRotation(targetPos);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed);
    // }

    // void LerpToTarget(Vector3 target)
    // {
    //     currentRot = Mathf.MoveTowards(currentRot, targetRot, speed);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(target), currentRot);
    // }
}
