using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// リザルト処理の前に確認する。
// https://mono-pro.net/archives/9253

// オイスターコントロールクラス、落下するオブジェクトの操作を管理する
public class OysterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    bool TouchFlg = false;
    public static bool Death = false;
    bool RenderFlg = false;

    int cnt = 0;

    // ドラッグ移動制御に使用する値
    Vector3 previousPos, currentPos;
    const float LOAD_WIDTH = 6f;
    const float MOVE_MAX = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
        previousPos = new Vector3(Screen.width/2, 0.0f, 0.0f);
        currentPos = new Vector3(Screen.width/2, 0.0f, 0.0f);

        TouchFlg = false;
        RenderFlg = false;

        //リジッドボディの取得（タッチで落下させる処理を行うため）
        rb2d = GetComponent<Rigidbody2D>();

        // オブジェクトをランダムで左右反転させる
        if (Random.Range(0, 2) == 1)
        {
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        // エフェクトが発生し終わってからキャラ表示
        StartCoroutine(RendererOn());

    }

    // Update is called once per frame
    void Update()
    {
        if(rb2d.gravityScale != 0.0f)
        {
            rb2d.gravityScale = 1.0f;
        }
        if(!(this.tag == "Untagged"))
        {
            return;
        }

        // 死亡フラグが確認されたら
        if (Death)
        {
            return;
        }

        // 落下速度を一定にする　基準値3.0を超えた場合、速度を再設定する
        if (rb2d.velocity.magnitude > 4.0f)
        {
            rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y/1.1f);
        }


        if (RenderFlg)
            cnt++;

        if(cnt > 20)
        {
            TouchFlg = true;
            cnt = 0;
        }

        // タッチ可能かつ描画されていれば
        if(TouchFlg)
        {
            // クリックして重力反映させ落下状態と回転を停止
            if (Input.GetMouseButtonUp(0))
            {
                rb2d.gravityScale = 1.0f;
                TouchFlg = false;
                RenderFlg = false;

            }

            // スワイプによる移動処理
            if (Input.GetMouseButtonDown(0))
            {
                // タップ位置を更新
                previousPos = Input.mousePosition;

            }

            // スワイプ処理、どこかのサイトからそのまま引っ張ってきた
            // 処理的には常に現在の座標を取得して、clamp関数で指定位置からはみ出さないように設定してる
            if (Input.GetMouseButton(0))
            {
                // スワイプによる移動距離を取得
                currentPos = Input.mousePosition;

                float diffDistance = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;

                // 次のローカルx座標を設定 ※外にでないように
                float newX = Mathf.Clamp(transform.localPosition.x + diffDistance, -MOVE_MAX, MOVE_MAX);
                transform.localPosition = new Vector3(newX, this.transform.localPosition.y, 0);

                // タップ位置を更新
                previousPos = currentPos;
            }

        }
    }

    void FixedUpdate()
    {
        // タッチした指が画面から離されたら回転を止める
        if (TouchFlg && !Death)
            Rotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // 何らかの物体と接触したら牡蠣君だけ、スコア計算のためにタグ情報を変更する
        if (this.tag == "Untagged")
        {
            this.tag = this.GetComponent<SpriteRenderer>().sprite.name.ToString();
            //           this.GetComponent<OysterController>().enabled = false;

            CreateBlock.instance.flg = true;
        }

        // 画面下部のゾーンに触れたらオブジェクト削除
        if (collision.gameObject.name == "DeathZone")
        {
            // 死亡フラグをオン
            Death = true;
            this.tag = "Untagged";
            // 「おわり！」アニメーションの再生に入る
            SetGameOverAnim();

            //Destroy(this.gameObject);
        }


    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1.0f));
    }

    void SetGameOverAnim()
    {
          // おわり！オブジェクトを取得
        GameObject end_anim = GameObject.Find("Canvas").transform.Find("End").gameObject;
        end_anim.SetActive(true);
        Animator anim = end_anim.GetComponent<Animator>();

        anim.SetBool("GameOverFlg",true);

    }

    private IEnumerator RendererOn()
    {
        // スタートアニメーション後に処理開始
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        RenderFlg = true;
    }
}
