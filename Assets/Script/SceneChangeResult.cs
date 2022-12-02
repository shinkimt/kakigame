using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeResult : MonoBehaviour
{
    int num = 0;

    bool flg = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // カゴからあふれたアイテムがデスゾーンに触れたらコルーチン動作
        if (flg)
            StartCoroutine(change());

        flg = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    // 1秒待ってからカゴの上のオブジェクトを数えて、画面遷移
    private IEnumerator change()
    {
        yield return new WaitForSeconds(2.0f);

        // 各牡蠣の数を数えて、一つの値にする
        GameObject[] kaki01 = GameObject.FindGameObjectsWithTag("kaki01");
        GameObject[] kaki02 = GameObject.FindGameObjectsWithTag("kaki02");
        GameObject[] kaki03 = GameObject.FindGameObjectsWithTag("kaki03");

        num += kaki01.Length * 100;
        num += kaki02.Length * 10;
        num += kaki03.Length;

        Debug.Log(num);

        SceneManager.sceneLoaded += KeepScore;

        FadeManager.Instance.LoadScene("Result", 1.0f);
    }

    // Result画面をロードした際に読み込まれる処理
    void KeepScore(Scene next, LoadSceneMode mode)
    {
        // ResultスクリプトのScore変数に牡蠣の数をセット
        var obj = GameObject.Find("Result").GetComponent<Result>();
        obj.Score = num;
        SceneManager.sceneLoaded -= KeepScore;
    }

}
