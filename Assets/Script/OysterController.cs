using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OysterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool Rotateflg = true;

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
        // ��ʃN���b�N�ŏd�͔��f����������ԂƉ�]��~
        if (Input.GetMouseButton(0))
        {
            rb2d.gravityScale = 1.0f;
            Rotateflg = false;
        }

    }
    void FixedUpdate()
    {
        if (Rotateflg)
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


}
