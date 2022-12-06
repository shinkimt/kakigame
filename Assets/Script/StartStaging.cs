using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartStaging : MonoBehaviour
{
    GameObject emitter;

    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        emitter = GameObject.Find("ObjEmitter");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //    text.text = Input.mousePosition.ToString();
    }
}
