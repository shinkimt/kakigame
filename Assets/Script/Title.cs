using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private bool firstPush = false;

    public AudioClip se;

    AudioSource audios;

    private void Start()
    {
        Screen.fullScreen = false;

        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;

        audios = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // タッチを離したら画面遷移開始
        if (Input.GetMouseButtonUp(0))
        {
            audios.PlayOneShot(se);
            PressStart();
        }
    }
    public void PressStart()
    {
        // 画面遷移処理の多重起動防止
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene("Game", 1.0f);
            firstPush = true;
        }
    }
}