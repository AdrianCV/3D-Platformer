using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Movement firstPlayerMovement, secondPlayerMovement;
    public Transform firstPlayerCamera, secondPlayerCamera, firstPlayer, secondPlayer;
    public Vector3 firstPlayerCameraRotation, secondPlayerCameraRotation;
    private float current, target, currentRot, targetRot;
    private float speed = 0.5f;
    private Vector3 currentPos, targetPos;
    private Transform lastTransform, lastPlayer;
    private bool rotateCamera = false, setXROt = false, xRotIsSet = false;
    // Start is called before the first frame update
    void Start()
    {
        target = 0;
        lastTransform = firstPlayer;
        lastPlayer = firstPlayer;
        firstPlayerCameraRotation = transform.rotation.eulerAngles;
        secondPlayerCameraRotation = secondPlayerCamera.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            target = target == 0 ? 1 : 0;
            targetRot = targetRot == 0 ? 1 : 0;
            lastTransform = lastTransform == secondPlayerCamera ? firstPlayerCamera : secondPlayerCamera;
            lastPlayer = lastPlayer == secondPlayer ? firstPlayer : secondPlayer;
            rotateCamera = true;
            setXROt = false;
            xRotIsSet = false;
            // if (lastPlayer == firstPlayer)
            // {
            //     secondPlayerCameraRotation = transform.rotation.eulerAngles;
            // }
            // else
            // {
            //     firstPlayerCameraRotation = transform.rotation.eulerAngles;
            // }
        }

        if (transform.rotation == lastTransform.rotation && rotateCamera) rotateCamera = false;
        if (rotateCamera)
        {
            RotateTowardsTarget(lastPlayer.position, transform.position, current);
        }

        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(firstPlayerCamera.position, secondPlayerCamera.position, current);
        currentPos = transform.position;

        if (currentPos == firstPlayerCamera.position)
        {
            secondPlayerMovement.canMove = false;
            firstPlayerMovement.canMove = true;
            setXROt = true;
            if (setXROt && !xRotIsSet)
            {
                firstPlayerMovement.xRotation = transform.rotation.x;
                xRotIsSet = true;
            }
        }
        else if (currentPos == secondPlayerCamera.position)
        {
            firstPlayerMovement.canMove = false;
            secondPlayerMovement.canMove = true;
            setXROt = true;
            if (setXROt && !xRotIsSet)
            {
                secondPlayerMovement.xRotation = transform.rotation.x;
                xRotIsSet = true;
            }
        }
        else
        {
            secondPlayerMovement.canMove = false;
            firstPlayerMovement.canMove = false;
        }
    }

    void RotateTowardsTarget(Vector3 target, Vector3 current, float speed)
    {
        targetPos = target - current;
        Quaternion toRotation = Quaternion.LookRotation(targetPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed);
    }

    void LerpToTarget(Vector3 target)
    {
        currentRot = Mathf.MoveTowards(currentRot, targetRot, speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(target), currentRot);
    }
}
