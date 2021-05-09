using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject range;
    private float speed = 0.5f;
    private GameObject player;
    private Rigidbody enemyRb;
    public Vector3 size;
    private MeshRenderer renderer;
    public float intXBounds;//interior bounds of the circle
    private float extXBounds;
    public float intZBounds;//interior bounds of the circle
    private float extZBounds;
    // Start is called before the first frame update
    void Start()
    {
        range = GameObject.Find("Range");
        renderer = range.GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        intXBounds = size.x;
        extXBounds = intZBounds + 10;
        intZBounds = size.z;
        extZBounds = intZBounds + 10;
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
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        /*if ((transform.position.x > -intXBounds || transform.position.x < intXBounds) || (transform.position.x > -intZBounds || transform.position.x < intZBounds))
        {
            speed = -speed;
        }
        else if ((transform.position.x < -extXBounds || transform.position.x > extXBounds) || (transform.position.x < -extZBounds || transform.position.x > extZBounds))
        {
            speed = -speed;
        }*/
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