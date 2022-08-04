using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OysterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool TouchFlg = true;

    // ドラッグ移動制御に使用する値
    Vector3 previousPos, currentPos;
    const float LOAD_WIDTH = 6f;
    const float MOVE_MAX = 2.5f;

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
        if(TouchFlg)
        {
            // クリック話て重力反映させ落下状態と回転停止
            if (Input.GetMouseButtonUp(0))
            {
                rb2d.gravityScale = 1.0f;
                TouchFlg = false;
            }

            // スワイプによる移動処理
            if (Input.GetMouseButtonDown(0))
            {
                previousPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                // スワイプによる移動距離を取得
                currentPos = Input.mousePosition;
                float diffDistance = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;

                // 次のローカルx座標を設定 ※道の外にでないように
                float newX = Mathf.Clamp(transform.localPosition.x + diffDistance, -MOVE_MAX, MOVE_MAX);
                transform.localPosition = new Vector3(newX, this.transform.localPosition.y, 0);

                // タップ位置を更新
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
        //マウスの座標を取得してスクリーン座標を更新
        Vector3 thisPosition = Input.mousePosition;
        //スクリーン座標→ワールド座標
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;

        this.transform.position = worldPosition;
    }


}
