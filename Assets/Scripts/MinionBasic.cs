﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBasic : MonoBehaviour
{
    public GameObject enemy;
    public GameObject projectile;
    private float shootCooldown;
    private float shootRatio;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0.0f;
        //projectile = GameObject.Find("BulletMaster");
        shootRatio = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= (Time.deltaTime * shootRatio);
        enemy = GameObject.FindWithTag("Enemy");
        Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 q1Pos = new Vector3(1,0,1);
        Vector3 q2Pos = new Vector3(-1,0,1);
        Vector3 q3Pos = new Vector3(-1,0,-1);
        Vector3 q4Pos = new Vector3(1,0,-1);
        if ((enemy.transform.position.x < 30 && enemy.transform.position.x > 0 && enemy.transform.position.z < 30 && enemy.transform.position.z > 0) && shootCooldown <= 0)
        {
            //Debug.Log("true q1" + enemy.transform.position);
            Instantiate(projectile, currentPos + q1Pos, enemy.transform.rotation, this.transform);
            shootCooldown = 3.0f;
        }
        else if ((enemy.transform.position.x > -30 && enemy.transform.position.x < 0 && enemy.transform.position.z < 30 && enemy.transform.position.z > 0) && shootCooldown <= 0)
        {
            //Debug.Log("true q2" + enemy.transform.position);
            Instantiate(projectile, currentPos + q2Pos, enemy.transform.rotation, this.transform);
            shootCooldown = 3.0f;
        }
        else if ((enemy.transform.position.x > -30 && enemy.transform.position.x < 0 && enemy.transform.position.z > -30 && enemy.transform.position.z < 0) && shootCooldown <= 0)
        {
            //Debug.Log("true q3" + enemy.transform.position);
            Instantiate(projectile, currentPos + q3Pos, enemy.transform.rotation, this.transform);
            shootCooldown = 3.0f;
        }
        else if((enemy.transform.position.x < 30 && enemy.transform.position.x > 0 && enemy.transform.position.z > -30 && enemy.transform.position.z < 0) && shootCooldown <= 0)
        {
            //Debug.Log("true q4" + enemy.transform.position);
            Instantiate(projectile, currentPos + q4Pos, enemy.transform.rotation, this.transform);
            shootCooldown = 3.0f;
        }
    }
}
