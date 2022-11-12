using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStaging : MonoBehaviour
{
    GameObject emitter;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GameObject.Find("ObjEmitter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
