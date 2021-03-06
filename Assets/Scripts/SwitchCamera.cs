using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject knightPrefab, magePrefab;
    [HideInInspector] public GameObject player, oldPlayer;
    //public Movement playerOneMovement, playerTwoMovement;
    public float speed;
    public int spawnOffset;
    public Vector3 offset;
    public Transform playerPosition, platformUp, platformDown;
    [HideInInspector] public bool spawnUp, spawnDown;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        player = playerPosition.gameObject;
        spawnDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPosition.position + offset, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (spawnUp)
            {
                oldPlayer = player;
                LayerMask mask = LayerMask.GetMask("RaycastGround");
                if (Physics.Raycast(player.transform.position, -player.transform.up, out hit, Mathf.Infinity, mask))
                {
                    platformDown = hit.transform;
                }
                // Vector3 dist = oldPlayer.transform.position - platformDown.position;
                // print(dist);
                player = Instantiate(knightPrefab, new Vector3(playerPosition.position.x, Vector3.Distance(platformDown.position, platformUp.position) + hit.distance, playerPosition.position.z), Quaternion.Euler(0, 90, 0));
                spawnUp = false;
                spawnDown = true;
                Destroy(oldPlayer);
            }
            else if (spawnDown)
            {
                oldPlayer = player;
                LayerMask mask = LayerMask.GetMask("RaycastGround");
                if (Physics.Raycast(player.transform.position, -player.transform.up, out hit, Mathf.Infinity, mask))
                {
                    platformUp = hit.transform;
                }
                // Vector3 dist = oldPlayer.transform.position - platformUp.position;
                // print(dist);
                player = Instantiate(magePrefab, new Vector3(playerPosition.position.x, hit.distance, playerPosition.position.z), Quaternion.Euler(0, 90, 0));
                spawnDown = false;
                spawnUp = true;
                Destroy(oldPlayer);
            }
            playerPosition = player.transform;
        }
    }
}