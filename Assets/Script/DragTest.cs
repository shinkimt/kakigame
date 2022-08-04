using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTest : MonoBehaviour
{

    bool isRunning;

    const float LOAD_WIDTH = 6f;
    const float MOVE_MAX = 2.5f;
    Vector3 previousPos, currentPos;

    void Start()
    {
    }

    void Update()
    {
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

        isRunning = true;
    }
}