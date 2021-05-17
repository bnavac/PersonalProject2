using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button instructionsButton;
    public Button backButton;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI timerText;
    public float seconds = 0.0f;
    private float timer2 = 0.0f;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        seconds += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer2 >= 1.0f) 
        {
            time++;
            timer2 = 0.0f;
        }
        timerText.text = "Time: " + time;
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("PersonalProj2Final", LoadSceneMode.Single);
    }
    public void Instructions() 
    {
        startButton.gameObject.SetActive(false);
        instructionsButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }
    public void Back()
    {
        startButton.gameObject.SetActive(true);
        instructionsButton.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        instructionsText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}
