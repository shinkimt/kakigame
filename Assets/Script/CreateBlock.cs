using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // �v���n�u�i�[�p
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ��莞�Ԃ��ƂɃv���n�u�𐶐�
        if (Time.frameCount % 100 == 0)
        {
            // �����ʒu
            Vector3 pos = new Vector3(0.0f, 4.0f, 0.0f);
            // �v���n�u���w��ʒu�ɐ���
            Instantiate(Prefab, pos, Quaternion.identity);
        }
    }
}