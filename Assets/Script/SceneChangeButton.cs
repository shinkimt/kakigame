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
        // ‘JˆÚæ‚ğw’è‚·‚é‚½‚ßAƒ{ƒ^ƒ“–¼‚ğæ“¾‚·‚é
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
        // ‰æ–Ê‘JˆÚˆ—‚Ì‘½d‹N“®–h~
        if (!firstPush)
        {
            FadeManager.Instance.LoadScene(objname, 1.0f);
            firstPush = true;
        }
    }
}