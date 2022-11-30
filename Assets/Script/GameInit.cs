using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameInit : MonoBehaviour
{

    public AudioClip se;

    AudioSource audios;

    public static int high_Score = 0;
    //static int tmp_score = 0;
    public Text text1;
    public Text text2;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;

        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;

        audios = GetComponent<AudioSource>();

        text1.text = high_Score.ToString();
        text2.text = high_Score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            audios.PlayOneShot(se);
    }
}
