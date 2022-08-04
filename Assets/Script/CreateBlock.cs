using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // プレハブ格納用
    public GameObject Prefab;

    bool flg = false;

    int num = 0;

    private void Awake()
    {
        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;
        Screen.fullScreen = true;

    }
    // Start is called before the first frame update
    void Start()
    {

        // 生成位置
        Vector3 pos = new Vector3(0.0f, 4.0f, 0.0f);
        // プレハブを指定位置に生成
        Instantiate(Prefab, pos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            flg = true;
        }

        if (flg)
            num++;

        if (num == 100)
        {
            // 生成位置
            Vector3 pos = new Vector3(0.0f, 4.0f, 0.0f);
            // プレハブを指定位置に生成
            Instantiate(Prefab, pos, Quaternion.identity);
            num = 0;
            flg = false;
        }

    }
}