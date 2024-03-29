﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    private float speed = 10.0f;
    Rigidbody bulletRb;
    public GameObject enemy;
    public GameObject parentObj;
    private Transform enemyTransform;
    private Vector3 enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemyTransform = enemy.transform;
        bulletRb = GetComponent<Rigidbody>();
        transform.LookAt(enemyTransform);
        enemyPos = enemyTransform.position;
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(enemyPos * speed * Time.deltaTime);
        /*
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, enemyPos, step);
        if (!enemy) 
        {
            Vector3 bulletPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            transform.position = Vector3.MoveTowards(this.transform.position, bulletPos, step);
        }*/
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bounds"))
        {
            Destroy(this.gameObject);
        }
    }
}
