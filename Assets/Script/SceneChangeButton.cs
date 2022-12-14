using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    private bool firstPush = false;
    string objname = null;

    private void Start()
    {
        // 遷移先を指定するため、ボタン名を取得する
        objname = this.name;
    }

    private void Update()
    {
    }

    public void ButtonClicked()
    {
        PressStart();
    }
    public void PressStart()
    {
        // 画面遷移処理の多重起動防止
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene(objname, 1.0f);
            firstPush = true;
        }
    }
}