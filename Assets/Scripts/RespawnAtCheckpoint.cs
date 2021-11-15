using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RespawnAtCheckpoint : MonoBehaviour
{
    public Vector3 Respawnpos;
    [SerializeField] Transform player;
    public int Life = 3;
    public bool dead;

    private void OnTriggerEnter(Collider other)

    {
       
                  
       if (other.gameObject.tag == "Respawn")
        {
            Life--;
            
            transform.position = Respawnpos;
           
          
            if (Life == 0)
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
