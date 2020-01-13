using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextTest : MonoBehaviour
{
    public ImageLoading imageLoading;
    public ImageFadeAway imageFadeAway;
    public GameObject m_gameObject;
    public PlayerControl playerControl;

    public void OnBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnBtnClick_2()
    {
        m_gameObject.SetActive(false);
        playerControl.allowToRun = true;
    }
}
