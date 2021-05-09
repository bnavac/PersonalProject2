using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnManager;
    public bool restart;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        player = GameObject.Find("SpawnController");
        restart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart) 
        {
            SceneManager.LoadScene("PersonalProj2.9", LoadSceneMode.Single);
        }
    }
}
