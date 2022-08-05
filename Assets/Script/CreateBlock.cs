using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // �v���n�u�i�[�p
    public GameObject[] Prefab = new GameObject[2];

    bool flg = false;
    bool ScrollFlg = false;

    int RepopCnt = 0;
    int ScrollCnt = 0;


    private void Awake()
    {
        // �A�v���t���[�����[�g��60fps�ɐݒ�
        Application.targetFrameRate = 60;
        Screen.fullScreen = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        // ���y�v���n�u���G�~�b�^�[�̈ʒu�ɐ���
        Instantiate(Prefab[Random.Range(0,2)], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // ��ʃN���b�N�������ƈ�莞�Ԍ�ɉ��y����
        if (Input.GetMouseButtonUp(0))
        {
            flg = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(RepopCnt);


        if (flg)
            RepopCnt++;

        // ��莞�Ԍo�ߌ�
        if (RepopCnt == 100)
        {
            // ���C��^���ɔ�΂��A�G�~�b�^�[�߂��ɃI�u�W�F�N�g���Ȃ����`�F�b�N
            Vector3 pos = gameObject.transform.position;
            pos.y = -5.0f;
            Debug.DrawRay(gameObject.transform.position, pos, Color.red, 0.1f);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, pos);
            Debug.Log(hit.distance);

            // �I�u�W�F�N�g���߂��ꍇ�J�����ƃG�~�b�^�[�S�̂�������Ɉړ�������B
            if (hit.distance < 4.0f)
            {
                ScrollFlg = true;
            }
            else
            {
                // �v���n�u���w��ʒu�ɐ���
                Instantiate(Prefab[Random.Range(0, 2)], transform.position, Quaternion.identity);
                RepopCnt = 0;
                flg = false;

            }

        }

        if (ScrollFlg)
        {
            GameObject obj = GameObject.Find("Scroll");
            Transform my = obj.transform;
            my.Translate(0.0f, 0.01f, 0.0f);
            ScrollCnt++;
            if (ScrollCnt >= 60)
            {
                ScrollFlg = false;
                ScrollCnt = 0;

                // �v���n�u���w��ʒu�ɐ���
                Instantiate(Prefab[Random.Range(0, 2)], transform.position, Quaternion.identity);
                RepopCnt = 0;
                flg = false;

            }

        }

    }
}