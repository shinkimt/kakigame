using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    private bool firstPush = false;
    string objname = null;

    private void Start()
    {
        // �J�ڐ���w�肷�邽�߁A�{�^�������擾����
        objname = this.name;
    }

    private void Update()
    {
    }

    public void ButtonClicked()
    {
        PressStart();
    }
    public void PressStart()
    {
        // ��ʑJ�ڏ����̑��d�N���h�~
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene(objname, 1.0f);
            firstPush = true;
        }
    }
}