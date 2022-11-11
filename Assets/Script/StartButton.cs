using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
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
        // ‰æ–Ê‘JˆÚˆ—‚Ì‘½d‹N“®–h~
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene("Game", 1.0f);
            firstPush = true;
        }
    }
}