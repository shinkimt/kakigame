using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Shake()
    {
        // スタートアニメーション後に処理開始
        yield return new WaitForSeconds(1.0f);
        var s = GetComponent<Cinemachine.CinemachineImpulseSource>();
        s.GenerateImpulse();
    }
}
