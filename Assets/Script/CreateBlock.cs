using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // �v���n�u�i�[�p
    public GameObject Prefab;

    bool flg = false;

    int num = 0;

    private void Awake()
    {
        // �A�v���t���[�����[�g��60fps�ɐݒ�
        Application.targetFrameRate = 60;
        Screen.fullScreen = true;

    }
    // Start is called before the first frame update
    void Start()
    {

        // �����ʒu
        Vector3 pos = new Vector3(0.0f, 4.0f, 0.0f);
        // �v���n�u���w��ʒu�ɐ���
        Instantiate(Prefab, pos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            flg = true;
        }

        if (flg)
            num++;

        if (num == 100)
        {
            // �����ʒu
            Vector3 pos = new Vector3(0.0f, 4.0f, 0.0f);
            // �v���n�u���w��ʒu�ɐ���
            Instantiate(Prefab, pos, Quaternion.identity);
            num = 0;
            flg = false;
        }

    }
}