using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    private float speed = 10.0f;
    Rigidbody bulletRb;
    public GameObject enemy;
    public GameObject parentObj;
    private Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponentInParent<MinionBasic>().enemy;
        enemyTransform = enemy.transform;
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.LookAt(enemyTransform);
        if (enemy == null) 
        {
            Debug.Log("true");
            Destroy(this.gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, enemyTransform.position, step);
        
    }
}
