using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sing CodeMonkey.Utils;
//Note to future self, next time I work on this, fix the spawnAngle stuff.

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float forwardInput;
    public float speed = 12.0f;
    public int[,] numOfFollowers = new int[2, 8];
    Rigidbody playerRb;
    public Vector3 inputs;
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
    }
    int getSpawnAngle(int i, int j) 
    {
        return numOfFollowers[i,j];
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 inputs = new Vector3(horizontalInput, 0, forwardInput);
        playerRb.MovePosition(transform.position + inputs * Time.deltaTime * speed);
    }
    public float getSpeed()
    {
        return speed;
    }
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            Destroy(this.gameObject);
            Debug.Log("Game Over");
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