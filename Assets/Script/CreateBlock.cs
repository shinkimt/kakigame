using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 落下オブジェクト（牡蠣）を管理、出現させるための処理をまとめたクラス
// GameシーンのObjEmitterにアタッチする
public class CreateBlock : MonoBehaviour
{
    // プレハブ格納用
    // 落下オブジェクトのデータを格納、確率調整のため、牡蠣6、その他3の設定
    public GameObject[] Prefab = new GameObject[9];

    // 牡蠣生成を管理するフラグ
    bool flg = true;
    // 牡蠣が積み重なりスクロールするか否かを管理するフラグ
    bool ScrollFlg = false;

    // リポップ管理のカウント
    int RepopCnt;
    // スクロール時間管理のカウント
    int ScrollCnt = 0;
    // リポップまでの基準の値、エディタ側で設定する、初期値は100
    public int Check_Cnt;

    public AudioClip[] audioc = new AudioClip[2];
    AudioSource audios;

    int randtmp = 0;

    private void Start()
    {
        audios = GetComponent<AudioSource>();
        Screen.fullScreen = false;

    }

    private void Update()
    {
        // 画面クリックしたあと一定時間後に牡蠣生成
        if (Input.GetMouseButtonUp(0))
        {
            audios.PlayOneShot(audioc[1]);
            flg = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // オブジェクト出現種類をランダムで設定
        randtmp = Random.Range(0, 9);

        if (flg)
            RepopCnt++;

        // 一定時間経過後かつ画面がスクロールしていない
        if (RepopCnt > Check_Cnt && ScrollFlg == false)
        {
            // レイを真下に飛ばし、エミッター近くにオブジェクトがないかチェック
            Vector3 pos = gameObject.transform.position;
            pos.y = -5.0f;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, pos);

            // オブジェクトが近い場合カメラとエミッター全体を上方向に移動させる。
            if (hit.distance < 4.0f)
            {
                ScrollFlg = true;
            }
            else
            {
                // 落下オブジェクトを指定位置に生成
                FallObjPop();
            }

        }

        // スクロールフラグがtrueであれば、画面全体を少し上にスクロールさせる
        if (ScrollFlg)
        {
            GameObject obj = GameObject.Find("Scroll");
            Transform my = obj.transform;
            my.Translate(0.0f, 0.01f, 0.0f);

            // スクロール時間は約1秒
            ScrollCnt++;
            if (ScrollCnt >= 60)
            {
                ScrollFlg = false;
                ScrollCnt = 0;

                FallObjPop();
            }

        }

    }

    // 落下オブジェクトを生成、各種フラグ情報などをリセットする
    void FallObjPop()
    {
        // プレハブを指定位置に生成
        Instantiate(Prefab[randtmp], transform.position, Quaternion.identity);
        RepopCnt = 0;
        flg = false;
        audios.PlayOneShot(audioc[0]);
    }
}