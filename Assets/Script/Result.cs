using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// リザルト画面を管理するクラス
public class Result : MonoBehaviour
{
    // 属性管理用の列挙
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
        COUNT=9,
        IMAITI=10,
        OMIGOTO=11,
        APPARE=12
    };


    bool k1 = true;

    public int Score = 0;
    int Result_Score = 0;
    int kaki1, kaki2, kaki3;
    GameObject[] objs = new GameObject[10];
    public Sprite[] sprites = new Sprite[13];

    // 最終評価が出力されたらタップでタイトルへ
    //メモ：0～3いまいち　4～7おみごと 7～あっぱれ
    private bool process_end_flg = false;

    string[] str = { 
        "kaki1ones", "kaki1tens",
        "kaki2ones", "kaki2tens", 
        "kaki3ones", "kaki3tens", 
        "tens", "ones", "result","count"
    };

    void Start()
    {
        // 前シーンから取得したスコア情報を分割して保存
        kaki1 = Score / 100; Score %= 100;
        kaki2 = Score / 10;  Score %= 10;
        kaki3 = Score;

        // 合計スコア表示用に計算
        Score = kaki1 + kaki2 + kaki3;
        // 評価表示用に計算
        Result_Score = Score;

        // 非アクティブ化しているUIオブジェクトを取得
        int i = 0;
        foreach(string a in str)
        {
            objs[i] = GameObject.Find("Canvas").transform.Find(str[i]).gameObject;
            i++;
        }

        // 牡蠣の個数を判別して描画設定を変更する処理
        StartCoroutine(kaki1_num());// 遷移から2秒後
        StartCoroutine(kaki2_num());// 遷移から3秒後
        StartCoroutine(kaki3_num());// 遷移から4秒後
        StartCoroutine(Score_num());// 遷移から5.5秒後

        // 総合評価スタンプを表示する処理
        StartCoroutine(Stamp());// 遷移から7.5秒後
    }

    void Update()
    {
        // マウスクリックでタイトル画面へ遷移
        if (Input.GetMouseButtonUp(0) && process_end_flg)
        {
            FadeManager.Instance.LoadScene("Title", 1.0f);
        }
    }

    // 牡蠣種類に合わせたスコア表示（2桁対応）
    // 牡蠣１～３にそれぞれ用意、ループで対応したかったが、
    // 変更要素と時間差による処理演出の都合上、分割
    private IEnumerator kaki1_num()
    {
        yield return new WaitForSeconds(2.0f);

        // スコアを1の桁10の桁に分割
        int tens = kaki1 / 10;
        kaki1 %= 10;
        int ones = kaki1;

        // Imageコンポーネントを取得
        Image img_ones = objs[(int)UI_OBJS.KAKI1ONES].GetComponent<Image>();
        Image img_tens = objs[(int)UI_OBJS.KAKI1TENS].GetComponent<Image>();

        // スプライト情報に、計算で割り出した数値画像をあてはめる
        img_ones.sprite = sprites[ones];
        img_tens.sprite = sprites[tens];

        // スコアに合わせた画像を設定したオブジェクトをアクティブに
        objs[(int)UI_OBJS.KAKI1ONES].SetActive(true);
        objs[(int)UI_OBJS.KAKI1TENS].SetActive(true);

    }

    private IEnumerator kaki2_num()
    {
        yield return new WaitForSeconds(3.0f);

        // スコアを1の桁10の桁に分割
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

        // スコアを1の桁10の桁に分割
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

        // Canvasにある結果表示用オブジェクト(result)を取得する
        Image img_result = objs[(int)UI_OBJS.RESULT].GetComponent<Image>();

        //メモ：0～3いまいち　4～7おみごと 7～あっぱれ
        // sprites[]10いまいち 11おみごと 12あっぱれ
        if (Result_Score >= 0 && Result_Score <= 3)
            img_result.sprite = sprites[(int)UI_OBJS.IMAITI];
        else if(Result_Score >= 4 && Result_Score <= 7)
            img_result.sprite = sprites[(int)UI_OBJS.OMIGOTO];
        else if (Result_Score >= 7)
            img_result.sprite = sprites[(int)UI_OBJS.APPARE];

        objs[(int)UI_OBJS.RESULT].SetActive(true);

        process_end_flg = true;
    }

}
