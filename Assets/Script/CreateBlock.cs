using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // �v���n�u�i�[�p
    public GameObject[] Prefab = new GameObject[6];

    bool flg = false;
    bool ScrollFlg = false;

    int RepopCnt = 0;
    int ScrollCnt = 0;

    public AudioClip[] audioc = new AudioClip[2];
    AudioSource audios;

    int randtmp = 0;

    private void Awake()
    {


    }
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        // ���y�v���n�u���G�~�b�^�[�̈ʒu�ɐ���
        Instantiate(Prefab[Random.Range(0,6)], transform.position, Quaternion.identity);
        audios.PlayOneShot(audioc[0]);
    }

    private void Update()
    {
        // ��ʃN���b�N�������ƈ�莞�Ԍ�ɉ��y����
        if (Input.GetMouseButtonUp(0))
        {
            audios.PlayOneShot(audioc[1]);
            flg = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        randtmp = Random.Range(0, 6);
        Debug.Log(RepopCnt);


        if (flg)
            RepopCnt++;

        // ��莞�Ԍo�ߌ�
        if (RepopCnt > 100)
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
                Instantiate(Prefab[Random.Range(0, 6)], transform.position, Quaternion.identity);
                RepopCnt = 0;
                flg = false;
                audios.PlayOneShot(audioc[0]);
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
                Instantiate(Prefab[Random.Range(0, 6)], transform.position, Quaternion.identity);
                RepopCnt = 0;
                flg = false;
                audios.PlayOneShot(audioc[0]);


            }

        }

    }
}