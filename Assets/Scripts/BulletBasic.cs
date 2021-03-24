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
    private Vector3 enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponentInParent<MinionBasic>().enemy;
        enemyTransform = enemy.transform;
        bulletRb = GetComponent<Rigidbody>();
        transform.LookAt(enemyTransform);
        enemyPos = enemyTransform.position;
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, enemyPos, step);
        
    }
}
