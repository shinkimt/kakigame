using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GetTime : MonoBehaviour
{
    DateTime dt;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dt = DateTime.Now;
        text.text = dt.ToString();
    }
}
