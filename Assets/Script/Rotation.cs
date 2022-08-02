using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    bool flg = true;
    // Start is called before the first frame update
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
        flg = false;
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1.0f));
    }
}
