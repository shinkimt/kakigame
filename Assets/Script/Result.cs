using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public int Score = 0;
    int kaki1, kaki2, kaki3;
    GameObject[] objs = new GameObject[6];
    public Sprite[] sprites = new Sprite[13];

    string[] str = { "kaki1", "kaki2", "kaki3", "juu", "iti", "result" };

    void Start()
    {
        // 前シーンから取得したスコア情報を分割して保存
        kaki1 = Score / 100; Score %= 100;
        kaki2 = Score / 10;  Score %= 10;
        kaki3 = Score;

        kaki1 = 9;

        // 非アクティブ化しているUIオブジェクトを取得
        int i = 0;
        foreach(string a in str)
        {
            objs[i] = GameObject.Find("Canvas").transform.Find(str[i]).gameObject;
            i++;
        }
    }

    void Update()
    {
       // 牡蠣１の個数を判別する処理
       StartCoroutine(kaki1_num());
       objs[0].SetActive(true);

        // マウスクリックでタイトル画面へ遷移
        if (Input.GetMouseButtonUp(0))
        {
            FadeManager.Instance.LoadScene("Title", 1.0f);
        }
    }

    private IEnumerator kaki1_num()
    {
        yield return new WaitForSeconds(1.0f);
        Image img = objs[0].GetComponent<Image>();
        img.sprite = sprites[kaki1 - 1];
    }

}
