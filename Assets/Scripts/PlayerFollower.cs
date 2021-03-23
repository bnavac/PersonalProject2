
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject followedObject;
    public Transform playerTransform;
    private Vector3 offset;
    private Vector3 position;
    private Rigidbody followerRb;
    private int speed = 0;
    private int spawnAngle;
    //int firstRow = 0;this will be finished later
    //int secondRow = 0;
    // Start is called before the first frame update
    void Start()
    {
        followedObject = GameObject.Find("Player");
        followerRb = GetComponent<Rigidbody>();
        playerTransform = followedObject.transform;
        offset.x = transform.position.x - playerTransform.position.x;
        offset.z = transform.position.z - playerTransform.position.z;
        transform.position = new Vector3(offset.x, 1, offset.z);
        //spawnAngle = player.GetComponent<PlayerController>.getgetSpawnAngle();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform.position);
        followerRb.AddForce(transform.forward * speed);
        Vector3 playerPos = playerTransform.position;
        float distance = Vector3.Distance(playerPos, transform.position);
        //Debug.Log(distance);
        if (distance <= 5)
        {
            speed = 0;
        }
        else
        {
            speed = 5;
        }

    }
}