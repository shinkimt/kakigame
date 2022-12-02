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
        // �J�S���炠�ӂꂽ�A�C�e�����f�X�]�[���ɐG�ꂽ��R���[�`������
        if (flg)
            StartCoroutine(change());

        flg = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    // 1�b�҂��Ă���J�S�̏�̃I�u�W�F�N�g�𐔂��āA��ʑJ��
    private IEnumerator change()
    {
        yield return new WaitForSeconds(2.0f);

        // �e���y�̐��𐔂��āA��̒l�ɂ���
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

    // Result��ʂ����[�h�����ۂɓǂݍ��܂�鏈��
    void KeepScore(Scene next, LoadSceneMode mode)
    {
        // Result�X�N���v�g��Score�ϐ��ɉ��y�̐����Z�b�g
        var obj = GameObject.Find("Result").GetComponent<Result>();
        obj.Score = num;
        SceneManager.sceneLoaded -= KeepScore;
    }

}
