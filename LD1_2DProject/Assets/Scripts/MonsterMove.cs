using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float rate;
    public int distance;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveMonsterRight", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveMonsterRight()
    {
        Vector3 pos = transform.position;
        pos.x += rate;
        transform.position = pos;
        counter++;
        if(counter > distance)
        {
            counter = 0;
            CancelInvoke();
            InvokeRepeating("MoveMonsterLeft", 0f, 0.1f);
        }
    }
    void MoveMonsterLeft()
    {
        Vector3 pos = transform.position;
        pos.x -= rate;
        transform.position = pos;
        counter++;
        if (counter > distance)
        {
            counter = 0;
            CancelInvoke();
            InvokeRepeating("MoveMonsterRight", 0f, 0.1f);
        }
    }
}
