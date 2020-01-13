using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
    public FadeInOut m_Fade;
    public SceneControlor m_SceneControlor;
    public FadeInOut.FadeType fadeType;

    public void OnBtnClick()
    {
        //加载场景
        StartCoroutine(m_SceneControlor.LoadScene("D1_Room", fadeType = FadeInOut.FadeType.FadeIn));
    }

    public void OnBtnClick2()
    {
        //离开游戏
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
