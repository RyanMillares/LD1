using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPlatform : MonoBehaviour
{
    public int distance;
    public float range;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveItRight", 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveItRight()
    {
        Vector3 first = transform.position;
        first.y += range;
        transform.position = first;
        counter++;
        if (counter > distance)
        {
            CancelInvoke();
            counter = 0;
            InvokeRepeating("MoveItLeft", 0f, 0.1f);
        }

    }
    public void MoveItLeft()
    {
        Vector3 first = transform.position;
        first.y -= range;
        transform.position = first;
        counter++;
        if (counter > distance)
        {
            CancelInvoke();
            counter = 0;
            InvokeRepeating("MoveItRight", 0f, 0.1f);
        }
    }
}