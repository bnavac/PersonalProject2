using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sing CodeMonkey.Utils;
//Note to future self, next time I work on this, fix the spawnAngle stuff.

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float forwardInput;
    public float speed = 15.0f;
    public int[,] numOfFollowers = new int[2, 8];
    private Rigidbody playerRb;
    public Vector3 inputs;
    public GameObject gameController;
    private Animator playerAnim;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float tapSpeed = 0.1f;
    private float lastTapTime = 0;
    private bool canSprint = true;//Bools checking if the player can use powerups.
    private bool canClear = true;
    public ParticleSystem speedParticle;
    public ParticleSystem clearParticle;
    public AudioClip speedSound;
    public AudioClip clearSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameController = GameObject.Find("GameManger");
        playerAudio = GetComponent<AudioSource>();
    }
    int getSpawnAngle(int i, int j) 
    {
        return numOfFollowers[i,j];
    }
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 inputs = new Vector3(horizontalInput, 0, forwardInput);
        playerRb.MovePosition(transform.position + inputs * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.W))
        {

            if (canSprint && (Time.time - lastTapTime) < tapSpeed)//activates if the user taps W twice within lastTapTime
            {
                StartCoroutine(sprint());
            }
            lastTapTime = Time.time;
        }
        if (canClear && Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(clearScreen());
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            gameController.GetComponent<GameRestart>().GameOver();
        }
    }
    IEnumerator sprint() 
    {
        playerAudio.PlayOneShot(speedSound, 1.0f);
        speedParticle.Play();
        speed *= (float) 1.5;
        canSprint = false;
        yield return new WaitForSeconds(10);//Deactivates powerup
        speed /= (float) 1.5;
        yield return new WaitForSeconds(20);//Allows the user to sprint again
        canSprint = true;
    }
    IEnumerator clearScreen() 
    {
        playerAudio.PlayOneShot(clearSound, 1.0f);
        clearParticle.Play();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        canClear = false;
        yield return new WaitForSeconds(30);
        canClear = true;
    }

}