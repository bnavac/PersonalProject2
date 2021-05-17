using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRestart : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnManager;
    public bool restart;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        player = GameObject.Find("SpawnController");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver() 
    {
        SceneManager.LoadScene("RestartSceneFinal", LoadSceneMode.Single);
    }
    public void GameOver2()
    {
        SceneManager.LoadScene("TitleScreenFinal", LoadSceneMode.Single);
    }

}
