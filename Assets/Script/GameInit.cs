using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{

    public AudioClip se;

    AudioSource audios;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;

        // �A�v���t���[�����[�g��60fps�ɐݒ�
        Application.targetFrameRate = 60;

        audios = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            audios.PlayOneShot(se);
    }
}
