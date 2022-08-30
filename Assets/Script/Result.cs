using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ���U���g��ʂ��Ǘ�����N���X
public class Result : MonoBehaviour
{
    // �����Ǘ��p�̗�
     enum UI_OBJS:int
    {
        KAKI1ONES=0,
        KAKI1TENS=1,
        KAKI2ONES=2,
        KAKI2TENS=3,
        KAKI3ONES=4,
        KAKI3TENS=5,
        TENS=6,
        ONES=7,
        RESULT=8,
        COUNT=9
    };


    bool k1 = true;

    //�����F0�`
    public int Score = 0;
    int kaki1, kaki2, kaki3;
    GameObject[] objs = new GameObject[10];
    public Sprite[] sprites = new Sprite[13];

    private bool process_end_flg = false;

    string[] str = { 
        "kaki1ones", "kaki1tens",
        "kaki2ones", "kaki2tens", 
        "kaki3ones", "kaki3tens", 
        "tens", "ones", "result","count"
    };

    void Start()
    {
        // �O�V�[������擾�����X�R�A���𕪊����ĕۑ�
        kaki1 = Score / 100; Score %= 100;
        kaki2 = Score / 10;  Score %= 10;
        kaki3 = Score;

        Score = kaki1 + kaki2 + kaki3;

        // ��A�N�e�B�u�����Ă���UI�I�u�W�F�N�g���擾
        int i = 0;
        foreach(string a in str)
        {
            objs[i] = GameObject.Find("Canvas").transform.Find(str[i]).gameObject;
            i++;
        }

        // ���y�̌��𔻕ʂ��ĕ`��ݒ��ύX���鏈��
        StartCoroutine(kaki1_num());
        StartCoroutine(kaki2_num());
        StartCoroutine(kaki3_num());
        StartCoroutine(Score_num());

        // �����]���X�^���v��\�����鏈��
        StartCoroutine(Stamp());
    }

    void Update()
    {
        // �}�E�X�N���b�N�Ń^�C�g����ʂ֑J��
        if (Input.GetMouseButtonUp(0) && process_end_flg)
        {
            FadeManager.Instance.LoadScene("Title", 1.0f);
        }
    }

    // ���y��ނɍ��킹���X�R�A�\���i2���Ή��j
    // ���y�P�`�R�ɂ��ꂼ��p�ӁA���[�v�őΉ��������������A
    // �ύX�v�f�Ǝ��ԍ��ɂ�鏈�����o�̓s����A����
    private IEnumerator kaki1_num()
    {
        yield return new WaitForSeconds(2.0f);

        // �X�R�A��1�̌�10�̌��ɕ���
        int tens = kaki1 / 10;
        kaki1 %= 10;
        int ones = kaki1;

        // Image�R���|�[�l���g���擾
        Image img_ones = objs[(int)UI_OBJS.KAKI1ONES].GetComponent<Image>();
        Image img_tens = objs[(int)UI_OBJS.KAKI1TENS].GetComponent<Image>();

        // �X�v���C�g���ɁA�v�Z�Ŋ���o�������l�摜�����Ă͂߂�
        img_ones.sprite = sprites[ones];
        img_tens.sprite = sprites[tens];

        // �X�R�A�ɍ��킹���摜��ݒ肵���I�u�W�F�N�g���A�N�e�B�u��
        objs[(int)UI_OBJS.KAKI1ONES].SetActive(true);
        objs[(int)UI_OBJS.KAKI1TENS].SetActive(true);

    }

    private IEnumerator kaki2_num()
    {
        yield return new WaitForSeconds(3.0f);

        // �X�R�A��1�̌�10�̌��ɕ���
        int tens = kaki2 / 10;
        kaki2 %= 10;
        int ones = kaki2;

        Debug.Log("tens" + tens.ToString());
        Debug.Log("ones" + ones.ToString());


        Image img_ones = objs[(int)UI_OBJS.KAKI2ONES].GetComponent<Image>();
        Image img_tens = objs[(int)UI_OBJS.KAKI2TENS].GetComponent<Image>();

        img_ones.sprite = sprites[ones];
        img_tens.sprite = sprites[tens];

        objs[(int)UI_OBJS.KAKI2ONES].SetActive(true);
        objs[(int)UI_OBJS.KAKI2TENS].SetActive(true);

    }

    private IEnumerator kaki3_num()
    {
        yield return new WaitForSeconds(4.0f);

        int tens = kaki3 / 10;
        kaki3 %= 10;
        int ones = kaki3;

        Debug.Log("tens" + tens.ToString());
        Debug.Log("ones" + ones.ToString());


        Image img_ones = objs[(int)UI_OBJS.KAKI3ONES].GetComponent<Image>();
        Image img_tens = objs[(int)UI_OBJS.KAKI3TENS].GetComponent<Image>();

        img_ones.sprite = sprites[ones];
        img_tens.sprite = sprites[tens];

        objs[(int)UI_OBJS.KAKI3ONES].SetActive(true);
        objs[(int)UI_OBJS.KAKI3TENS].SetActive(true);

    }

    private IEnumerator Score_num()
    {
        yield return new WaitForSeconds(5.5f);

        // �X�R�A��1�̌�10�̌��ɕ���
        int tens = Score / 10;
        Score %= 10;
        int ones = Score;

        Debug.Log("tens" + tens.ToString());
        Debug.Log("ones" + ones.ToString());


        Image img_ones = objs[(int)UI_OBJS.ONES].GetComponent<Image>();
        Image img_tens = objs[(int)UI_OBJS.TENS].GetComponent<Image>();

        img_ones.sprite = sprites[ones];
        img_tens.sprite = sprites[tens];

        objs[(int)UI_OBJS.ONES].SetActive(true);
        objs[(int)UI_OBJS.TENS].SetActive(true);
        objs[(int)UI_OBJS.COUNT].SetActive(true);

    }

    private IEnumerator Stamp()
    {
        yield return new WaitForSeconds(7.5f);

        process_end_flg = true;
    }

}
