using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //I did not mean to make everything public, but this is how it came out.
    public Button startButtonEasy;
    public Button startButtonMed;
    public Button startButtonHard;
    public Button startButtonImp;
    public Button instructionsButton;
    public Button backButton;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI timerText;
    public float seconds = 0.0f;
    public static float difficulty;    
    public bool diffInc;
    // Start is called before the first frame update
    void Start()
    {
        diffInc = false;
        if (difficulty != 0)//Activates the difficulty buttons.
        {
            switch (difficulty)
            {
                case 1.5f:
                    Debug.Log("Med");
                    startButtonMed.gameObject.SetActive(true);
                    break;
                case 2.0f:
                    Debug.Log("Hard");
                    startButtonHard.gameObject.SetActive(true);
                    break;
                case 2.5f:
                    Debug.Log("Imp");
                    startButtonImp.gameObject.SetActive(true);
                    break;
                default:
                    Debug.Log("Easy");
                    startButtonEasy.gameObject.SetActive(true);
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        seconds += Time.deltaTime;
        timerText.text = "Time: " + (int)seconds;
        if (!diffInc && seconds > 30.0f && difficulty != 2.5f)//checking that difficulty only increments once per level.
        {
            Debug.Log("Increased");
            difficulty += .5f;
            diffInc = true;
        }
        
    }
    //start game at different difficulties
    public void StartGameEasy() 
    {
        difficulty = 1f;
        SceneManager.LoadScene("PersonalProj2Final", LoadSceneMode.Single);
            
    }
    public void StartGameMed()
    {
        difficulty = 1.5f;
        SceneManager.LoadScene("PersonalProj2Final", LoadSceneMode.Single);
        
    }
    public void StartGameHard()
    {
        difficulty = 2f;
        SceneManager.LoadScene("PersonalProj2Final", LoadSceneMode.Single);
        
    }
    public void StartGameImp()
    {
        difficulty = 2.5f;
        SceneManager.LoadScene("PersonalProj2Final", LoadSceneMode.Single);
        
    }
    public void Instructions() 
    {
        SceneManager.LoadScene("InsturctionFinal", LoadSceneMode.Single);
    }
    public void Back()
    {
        SceneManager.LoadScene("TitleScreenFinal", LoadSceneMode.Single);
    }
}
