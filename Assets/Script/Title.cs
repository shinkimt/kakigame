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

        // �A�v���t���[�����[�g��60fps�ɐݒ�
        Application.targetFrameRate = 60;

        audios = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // �^�b�`�𗣂������ʑJ�ڊJ�n
        if (Input.GetMouseButtonUp(0))
        {
            audios.PlayOneShot(se);
            PressStart();
        }
    }
    public void PressStart()
    {
        // ��ʑJ�ڏ����̑��d�N���h�~
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene("Game", 1.0f);
            firstPush = true;
        }
    }
}