using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject stuff;
    public GameObject player;
    public GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpitFire", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpitFire()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 here = transform.position;
        Vector3 there = player.transform.position;
        Vector3 dir = (there-here).normalized;
        Debug.Log(dir);

        clone = Instantiate(stuff, transform.position, Quaternion.identity);
        clone.transform.Rotate(dir);
        //Debug.Log("hi");
    }
}
