using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //public GameObject CharObject;
    //public GameObject MenuCamera;
    //public Canvas canvas;
    public string level1;
    public string level2;
    private int increment = 1;
    // Start is called before the first frame update
    void Start()
    {
        //canvas.enabled = false;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            LoadLevel1();
        }
        if (Input.GetKeyDown("2"))
        {
            LoadLevel2();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            increment++;  
        }
   
    }
}
