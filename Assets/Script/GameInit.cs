using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;

        // アプリフレームレートを60fpsに設定
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
