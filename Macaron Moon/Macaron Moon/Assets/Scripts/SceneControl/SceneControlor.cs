using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlor : MonoBehaviour
{
    public FadeInOut m_FadeInOut;

    public IEnumerator LoadScene(string nextSceneName, FadeInOut.FadeType fadeType)
    {
        if(fadeType == FadeInOut.FadeType.FadeIn)
        {
            FadeInOut.fadeType = FadeInOut.FadeType.FadeIn;
        }

        if (fadeType == FadeInOut.FadeType.FadeOut)
        {
            FadeInOut.fadeType = FadeInOut.FadeType.FadeOut;
        }

        yield return StartCoroutine(m_FadeInOut.Fade());

        Globe.nextSceneName = nextSceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
