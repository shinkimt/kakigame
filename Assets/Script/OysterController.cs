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
        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;

        //リジッドボディの取得（タッチで落下させる処理を行うため）
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 画面クリックで重力反映させ落下状態と回転停止
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
