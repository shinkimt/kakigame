using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    private bool firstPush = false;

    public AudioClip se;

    AudioSource audios;

    private void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    public void ButtonClicked()
    {
        audios.PlayOneShot(se);
        PressStart();
    }
    public void PressStart()
    {
        // 画面遷移処理の多重起動防止
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene("Credit", 0.5f);
            firstPush = true;
        }
    }
}