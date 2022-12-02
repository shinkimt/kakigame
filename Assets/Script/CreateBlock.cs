using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����I�u�W�F�N�g�i���y�j���Ǘ��A�o�������邽�߂̏������܂Ƃ߂��N���X
// Game�V�[����ObjEmitter�ɃA�^�b�`����
public class CreateBlock : MonoBehaviour
{
    // �v���n�u�i�[�p
    // �����I�u�W�F�N�g�̃f�[�^���i�[�A�m�������̂��߁A���y6�A���̑�3�̐ݒ�
    public GameObject[] Prefab = new GameObject[9];

    // ���y�������Ǘ�����t���O
    bool flg = true;
    // ���y���ςݏd�Ȃ�X�N���[�����邩�ۂ����Ǘ�����t���O
    bool ScrollFlg = false;

    // ���|�b�v�Ǘ��̃J�E���g
    int RepopCnt;
    // �X�N���[�����ԊǗ��̃J�E���g
    int ScrollCnt = 0;
    // ���|�b�v�܂ł̊�̒l�A�G�f�B�^���Őݒ肷��A�����l��100
    public int Check_Cnt;

    public AudioClip[] audioc = new AudioClip[2];
    AudioSource audios;

    int randtmp = 0;
    int kaki_cnt = 0;

    GameObject scroll;

    private void Awake()
    {
        // �X�^�[�g�A�j���[�V�����̏�����ҋ@����
        StartCoroutine(StartWait()); 
    }


    private void Start()
    {
        audios = GetComponent<AudioSource>();
        Screen.fullScreen = false;

        scroll = GameObject.Find("Scroll");

        // �v���n�u���w��ʒu�ɐ���
        Instantiate(Prefab[randtmp], transform.position, Quaternion.identity);
        RepopCnt = 0;
        flg = false;
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
        // �I�u�W�F�N�g�o����ނ������_���Őݒ�
        randtmp = Random.Range(0, 9);


        if (flg)
            RepopCnt++;

        // ��莞�Ԍo�ߌォ��ʂ��X�N���[�����Ă��Ȃ�
        if (RepopCnt > Check_Cnt && ScrollFlg == false)
        {
            // ���C��^���ɔ�΂��A�G�~�b�^�[�߂��ɃI�u�W�F�N�g���Ȃ����`�F�b�N
            Vector3 pos = gameObject.transform.position;
            pos.y = -5.0f;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, pos);

            // �I�u�W�F�N�g���߂��ꍇ�J�����ƃG�~�b�^�[�S�̂�������Ɉړ�������B
            if (hit.distance < 4.0f)
            {
                ScrollFlg = true;
            }
            else
            {
                // �����I�u�W�F�N�g���w��ʒu�ɐ���
                FallObjPop();
            }

        }

        // �X�N���[���t���O��true�ł���΁A��ʑS�̂�������ɃX�N���[��������
        if (ScrollFlg)
        {
            Transform my = scroll.transform;
            my.Translate(0.0f, 0.01f, 0.0f);

            // �X�N���[�����Ԃ͖�1�b
            ScrollCnt++;
            if (ScrollCnt >= 60)
            {
                ScrollFlg = false;
                ScrollCnt = 0;

                FallObjPop();
            }

        }

    }

    // �����I�u�W�F�N�g�𐶐��A�e��t���O���Ȃǂ����Z�b�g����
    void FallObjPop()
    {
        if (randtmp >= 0 && randtmp <= 5)
        {
            kaki_cnt++;

            if (kaki_cnt == 5)
            {
                Debug.Log("kakipop");
                randtmp = 8;
                kaki_cnt = 0;
            }
        }
        // �v���n�u���w��ʒu�ɐ���
        Instantiate(Prefab[randtmp], transform.position, Quaternion.identity);
        RepopCnt = 0;
        flg = false;
        audios.PlayOneShot(audioc[0]);


    }

    private IEnumerator StartWait()
    {
        // �X�^�[�g�A�j���[�V������ɏ����J�n
        yield return new WaitForSeconds(3.3f);
        this.enabled = true;
    }


}