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
        // �A�v���t���[�����[�g��60fps�ɐݒ�
        Application.targetFrameRate = 60;
        Screen.fullScreen = true;
        audios = GetComponent<AudioSource>();
    }
    private void Update()
    {

        // �N���b�N�b�ďd�͔��f����������ԂƉ�]��~
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