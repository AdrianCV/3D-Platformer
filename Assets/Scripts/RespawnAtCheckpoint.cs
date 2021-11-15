using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RespawnAtCheckpoint : MonoBehaviour
{
    public Variables variables;
    public SwitchCamera cameraScript;
    public bool dead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            variables.health--;

            transform.position = variables.checkpoint;
            cameraScript.player = Instantiate(cameraScript.knightPrefab, new Vector3(cameraScript.playerPosition.position.x, Vector3.Distance(cameraScript.platformDown.position, cameraScript.platformUp.position) + cameraScript.hit.distance, cameraScript.playerPosition.position.z), Quaternion.Euler(0, 90, 0));
            cameraScript.spawnUp = false;
            cameraScript.spawnDown = true;
            Destroy(cameraScript.oldPlayer);


            if (variables.health == 0)
            {
                dead = true;
                Debug.Log("You are dead");
                LoadFirstLevel();
            }

            void LoadFirstLevel()
            {
                SceneManager.LoadScene(0);

            }
        }
    }
}
