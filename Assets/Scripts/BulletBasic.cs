using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    public GameObject enemy;
    private float speed = 30.0f;
    Rigidbody bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.AddForce(transform.position * speed * Time.deltaTime);
    }
}
