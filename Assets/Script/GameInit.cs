using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameInit : MonoBehaviour
{

    public AudioClip se;

    AudioSource audios;

    public static int high_Score = 0;
    //static int tmp_score = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;

        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;

        audios = GetComponent<AudioSource>();

        text.text = high_Score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            audios.PlayOneShot(se);
    }
}
