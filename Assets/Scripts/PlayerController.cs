using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sing CodeMonkey.Utils;
//Note to future self, next time I work on this, fix the spawnAngle stuff.

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float forwardInput;
    private float speed = 15.0f;
    public int[,] numOfFollowers = new int[2, 8];
    Rigidbody playerRb;
    public Vector3 inputs;
    public GameObject gameController;
    private Animator playerAnim;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float tapSpeed = 0.1f;
    private float lastTapTime = 0;
    private bool canSprint = true;
    private bool canClear = true;
    public GameObject speedCooldown;
    public GameObject clearCooldown;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        /*
        for (int i = 0; i < numOfFollowers.GetLength(0); i++)
        {
            for (int j = 0; j < numOfFollowers.GetLength(1); j++)
            {
                numOfFollowers[i,j] = 360 - (45 * j);
            }
        }
        */
        playerAnim = GetComponent<Animator>();
        gameController = GameObject.Find("GameManger");
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

            if (canSprint && (Time.time - lastTapTime) < tapSpeed)
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
    public float getSpeed()
    {
        return speed;
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
        Debug.Log("works");
        speed *= (float) 1.5;
        canSprint = false;
        speedCooldown.SetActive(true);
        yield return new WaitForSeconds(10);
        speedCooldown.SetActive(false);
        speed /= (float) 1.5;
        canSprint = true;
    }
    IEnumerator clearScreen() 
    {
        Debug.Log("works");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        canClear = false;
        clearCooldown.SetActive(true);
        yield return new WaitForSeconds(30);
        clearCooldown.SetActive(false);
        canClear = true;
    }
    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = UtilsClass.GetMouseWorldPosition();
            Debug.Log(targetPos);
            //mouseXInput = Input.GetAxis("Mouse X");
            //mouseYInput = Input.GetAxis("Mouse Y");
            //targetPos.x = mouseXInput;
            //targetPos.z = mouseYInput;
        }
        transform.Translate(Vector3.right * Time.deltaTime * targetPos.x * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * targetPos.y * speed);
    
    }
    */

}