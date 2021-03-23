using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    private float speed = 300.0f;
    Rigidbody bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < 30 && transform.position.x > 0 && transform.position.z < 30 && transform.position.z > 0))
        {
            Debug.Log("true q1");
            bulletRb.AddForce(Vector3.forward * speed * Time.deltaTime);
            bulletRb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        else if ((transform.position.x > -30 && transform.position.x < 0 && transform.position.z < 30 && transform.position.z > 0))
        {
            Debug.Log("true q2");
            bulletRb.AddForce(Vector3.forward * speed * Time.deltaTime);
            bulletRb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        else if ((transform.position.x > -30 && transform.position.x < 0 && transform.position.z > -30 && transform.position.z < 0))
        {
            Debug.Log("true q3");
            bulletRb.AddForce(Vector3.forward * -speed * Time.deltaTime);
            bulletRb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        else if ((transform.position.x < 30 && transform.position.x > 0 && transform.position.z > -30 && transform.position.z < 0))
        {
            Debug.Log("true q4");
            bulletRb.AddForce(Vector3.forward * -speed * Time.deltaTime);
            bulletRb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        
    }
}
