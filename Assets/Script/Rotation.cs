using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    // 回転のフラグ
    bool flg = true;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flg)
            Rotate();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //何かとぶつかるとフラグ変更→回転停止
        flg = false;
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1.0f));
    }
}
