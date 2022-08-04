using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OysterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool TouchFlg = true;

    // �h���b�O�ړ�����Ɏg�p����l
    Vector3 previousPos, currentPos;
    const float LOAD_WIDTH = 6f;
    const float MOVE_MAX = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        // �A�v���t���[�����[�g��60fps�ɐݒ�
        Application.targetFrameRate = 60;

        //���W�b�h�{�f�B�̎擾�i�^�b�`�ŗ��������鏈�����s�����߁j
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TouchFlg)
        {
            // �N���b�N�b�ďd�͔��f����������ԂƉ�]��~
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
        if (TouchFlg)
            Rotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DeathZone")
            Destroy(this.gameObject);
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1.0f));
    }

    void OnMouseDrag()
    {
        Debug.Log("test");
        //�}�E�X�̍��W���擾���ăX�N���[�����W���X�V
        Vector3 thisPosition = Input.mousePosition;
        //�X�N���[�����W�����[���h���W
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;

        this.transform.position = worldPosition;
    }


}
