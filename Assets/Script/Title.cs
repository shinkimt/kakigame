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


        if (Input.GetMouseButtonUp(0))
        {
            audios.PlayOneShot(se);
            PressStart();
        }
    }
    public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene("Game", 1.0f);
//            SceneManager.LoadScene("Game");
            firstPush = true;
        }
    }
}