using System.Collections;
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
        shootCooldown = 3.0f;
        //projectile = GameObject.Find("BulletMaster");
        shootRatio = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= (Time.deltaTime * shootRatio);
        enemy = GameObject.FindWithTag("Enemy");
        Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
        if ((enemy.transform.position.x <= 30 || enemy.transform.position.z <= 30) && shootCooldown <= 0)
        {
            Debug.Log("true");
            Instantiate(projectile, currentPos, enemy.transform.rotation);
            shootCooldown = 8.0f;
        }
        else if ((enemy.transform.position.x <= -30 || enemy.transform.position.z <= -30) && shootCooldown <= 0)
        {
            Debug.Log("true");
            Instantiate(projectile, currentPos, enemy.transform.rotation);
            shootCooldown = 8.0f;
        }
    }
}
