using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCode : MonoBehaviour
{
    public GameObject death;
    ParticleSystem ps;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /**
    private void OnParticleTrigger()
    {
        death.GetComponent<>
    }
    **/
}
