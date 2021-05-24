using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject range;
    private float speed = .25f;
    private GameObject player;
    private Rigidbody enemyRb;
    public Vector3 size;
    public MeshRenderer renderer;
    public float intXBounds;//interior bounds of the circle
    private float extXBounds;
    public float intZBounds;//interior bounds of the circle
    private float extZBounds;
    public float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        range = GameObject.Find("Range");
        renderer = range.GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        intXBounds = size.x;//bounds is used for spawning. Check SpawnManager for more details.
        extXBounds = intZBounds + 10;
        intZBounds = size.z;
        extZBounds = intZBounds + 10;
        Destroy(this.gameObject, 40);
        difficulty = GameManager.difficulty;//gets difficulty from gamemanager
        speed *= difficulty;
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
    void FixedUpdate()
    {
        player = GameObject.Find("Player");
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        var p1 = transform.position;
        var p2 = player.transform.position;
        var position = new Vector3(p2.x, p1.y, p2.z); //Gets the players position.
        transform.LookAt(position);//Rotates towards the player.
        transform.Translate(lookDirection.x * speed, lookDirection.y * speed, lookDirection.z * speed);//goes to the player.
        
    }
    //useless now, might finish over summer
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Bullet1")) 
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}