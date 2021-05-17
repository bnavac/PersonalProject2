using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sing CodeMonkey.Utils;
//Note to future self, next time I work on this, fix the spawnAngle stuff.

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float forwardInput;
    private float speed = 20.0f;
    public int[,] numOfFollowers = new int[2, 8];
    Rigidbody playerRb;
    public Vector3 inputs;
    public GameObject gameController;
    private Animator playerAnim;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        for (int i = 0; i < numOfFollowers.GetLength(0); i++)
        {
            for (int j = 0; j < numOfFollowers.GetLength(1); j++)
            {
                numOfFollowers[i,j] = 360 - (45 * j);
            }
        }
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
        if (horizontalInput == 0 && forwardInput == 0) 
        {
            //play idle animation
        }
        Vector3 inputs = new Vector3(horizontalInput, 0, forwardInput);
        playerRb.MovePosition(transform.position + inputs * Time.deltaTime * speed);
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        if (h < 0 && v < 0) 
        {
            transform.Rotate(0, h+v-180, 0);
        }
        else transform.Rotate(0, v, 0);

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