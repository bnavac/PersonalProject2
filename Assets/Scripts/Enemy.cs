using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 0.5f;
    private GameObject player;
    private Rigidbody enemyRb;
    public float intXBounds = 20.0f;//interior bounds of the circle
    private float extXBounds;
    public float intZBounds = 20.0f;//interior bounds of the circle
    private float extZBounds;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        extXBounds = intXBounds + 10.0f;
        extZBounds = intZBounds + 10.0f;
        Destroy(this.gameObject, 40);
        //speed = player.getSpeed() * .85; this will be added later 
    }
    public int getXBounds()
    {
        return ((int)intXBounds);
    }
    public int getZBounds()
    {
        return ((int)intZBounds);
    }
    // Update is called once per frame
    void Update()
    {
        //if ((transform.position.x > -intXBounds || transform.position.x < intXBounds) || (transform.position.x > -intZBounds || transform.position.x < intZBounds))
        //{
        //    speed = -speed;
        //}
        //else if ((transform.position.x < -extXBounds || transform.position.x > extXBounds) || (transform.position.x < -extZBounds || transform.position.x > extZBounds))
        //{
        //    speed = -speed;
        //}
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Bullet1")) 
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}