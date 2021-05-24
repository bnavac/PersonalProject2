using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownFollower : MonoBehaviour
{
    //There are no objects that use this script, they have been removed. The script is being saved due to the possiblity of further work on the project.
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
