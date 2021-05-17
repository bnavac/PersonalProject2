using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBasic : MonoBehaviour
{
    public GameObject enemy;
    public GameObject projectile;
    public GameObject range;
    public Vector3 size;
    public MeshRenderer renderer;
    private float shootCooldown;
    private float shootRatio;
    private Animator minionAnim;
    // Start is called before the first frame update
    void Start()
    {
        range = GameObject.Find("Range");
        renderer = range.GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
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
        minionAnim = GetComponent<Animator>();
        if ((enemy.transform.position.x < (currentPos.x + size.x/2) && enemy.transform.position.x > (currentPos.x) && enemy.transform.position.z < (currentPos.z + size.z / 2) && enemy.transform.position.z > (currentPos.z)) && shootCooldown <= 0)
        {
            //Debug.Log("true q1" + enemy.transform.position);
            Instantiate(projectile, currentPos + q1Pos, enemy.transform.rotation);
            shootCooldown = 2.5f;
        }
        else if ((enemy.transform.position.x > (currentPos.x - size.x / 2) && enemy.transform.position.x < (currentPos.x) && enemy.transform.position.z < (currentPos.z + size.z / 2) && enemy.transform.position.z > (currentPos.z)) && shootCooldown <= 0)
        {
            //Debug.Log("true q2" + enemy.transform.position);
            Instantiate(projectile, currentPos + q2Pos, enemy.transform.rotation);
            shootCooldown = 2.5f;
        }
        else if ((enemy.transform.position.x > (currentPos.x - size.x / 2) && enemy.transform.position.x < (currentPos.x) && enemy.transform.position.z > (currentPos.z - size.z / 2) && enemy.transform.position.z < (currentPos.z)) && shootCooldown <= 0)
        {
            //Debug.Log("true q3" + enemy.transform.position);
            Instantiate(projectile, currentPos + q3Pos, enemy.transform.rotation);
            shootCooldown = 2.5f;
        }
        else if((enemy.transform.position.x < (currentPos.x + size.x / 2) && enemy.transform.position.x > (currentPos.x) && enemy.transform.position.z > (currentPos.z - size.z / 2) && enemy.transform.position.z < (currentPos.z)) && shootCooldown <= 0)
        {
            //Debug.Log("true q4" + enemy.transform.position);
            Instantiate(projectile, currentPos + q4Pos, enemy.transform.rotation);
            shootCooldown = 2.5f;
        }
    }
}
