using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���U���g�����̑O�Ɋm�F����B
// https://mono-pro.net/archives/9253

// �I�C�X�^�[�R���g���[���N���X�A��������I�u�W�F�N�g�̑�����Ǘ�����
public class OysterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool TouchFlg = false;
    static bool Death = false;
    bool RenderFlg = false;

    // �h���b�O�ړ�����Ɏg�p����l
    Vector3 previousPos, currentPos;
    const float LOAD_WIDTH = 6f;
    const float MOVE_MAX = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
        
        TouchFlg = false;
        Death = false;
        RenderFlg = false;

        //���W�b�h�{�f�B�̎擾�i�^�b�`�ŗ��������鏈�����s�����߁j
        rb2d = GetComponent<Rigidbody2D>();

        // �I�u�W�F�N�g�������_���ō��E���]������
        if (Random.Range(0, 2) == 1)
        {
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        // �G�t�F�N�g���������I����Ă���L�����\��
        StartCoroutine(RendererOn());

    }

    // Update is called once per frame
    void Update()
    {

        // ���S�t���O���m�F���ꂽ��
        if (Death)
        {
            // �u�����I�v�A�j���[�V�����̍Đ��ɓ���
            SetGameOverAnim();
            return;
        }

        // �������x�����ɂ���@��l3.0�𒴂����ꍇ�A���x���Đݒ肷��
        if (rb2d.velocity.magnitude > 3.0f)
        {
            rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y/1.1f);
        }

        // �^�b�`�\���`�悳��Ă����
        if(TouchFlg && RenderFlg)
        {
            // �N���b�N���ďd�͔��f����������ԂƉ�]���~
            if (Input.GetMouseButtonUp(0))
            {
                rb2d.gravityScale = 1.0f;
                TouchFlg = false;
            }

            // �X���C�v�ɂ��ړ�����
            if (Input.GetMouseButtonDown(0))
            {
                previousPos = Input.mousePosition;
            }

            // �X���C�v�����A�ǂ����̃T�C�g���炻�̂܂܈��������Ă���
            // �����I�ɂ͏�Ɍ��݂̍��W���擾���āAclamp�֐��Ŏw��ʒu����͂ݏo���Ȃ��悤�ɐݒ肵�Ă�
            if (Input.GetMouseButton(0))
            {
                // �X���C�v�ɂ��ړ��������擾
                currentPos = Input.mousePosition;
                float diffDistance = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;

                // ���̃��[�J��x���W��ݒ� �����̊O�ɂłȂ��悤��
                float newX = Mathf.Clamp(transform.localPosition.x + diffDistance, -MOVE_MAX, MOVE_MAX);
                transform.localPosition = new Vector3(newX, this.transform.localPosition.y, 0);

                // �^�b�v�ʒu���X�V
                previousPos = currentPos;
            }

        }
    }

    void FixedUpdate()
    {
        // �^�b�`�����w����ʂ��痣���ꂽ���]���~�߂�
        if (TouchFlg && !Death)
            Rotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���炩�̕��̂ƐڐG�����牲�y�N�����A�X�R�A�v�Z�̂��߂Ƀ^�O����ύX����
        if(this.tag == "Untagged" )
            this.tag = this.GetComponent<SpriteRenderer>().sprite.name.ToString();

        // ��ʉ����̃]�[���ɐG�ꂽ��I�u�W�F�N�g�폜
        if (collision.gameObject.name == "DeathZone")
        {
            // ���S�t���O���I��
            Death = true;
            this.tag = "Untagged";
            //Destroy(this.gameObject);
        }
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1.0f));
    }

    void SetGameOverAnim()
    {
          // �����I�I�u�W�F�N�g���擾
        GameObject end_anim = GameObject.Find("Canvas").transform.Find("End").gameObject;
        end_anim.SetActive(true);
        Animator anim = end_anim.GetComponent<Animator>();

        anim.SetBool("GameOverFlg",true);

    }

    private IEnumerator RendererOn()
    {
        // �X�^�[�g�A�j���[�V������ɏ����J�n
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        RenderFlg = true;
        TouchFlg = true;
    }
}
