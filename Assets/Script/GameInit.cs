using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class GameInit : MonoBehaviour
{

    public AudioClip se;

    AudioSource audios;

    public static int high_Score = 0;
    //static int tmp_score = 0;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;

        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;

        audios = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "Title")
        {
            text1.text = high_Score.ToString();
            text2.text = high_Score.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            audios.PlayOneShot(se);
    }
}
