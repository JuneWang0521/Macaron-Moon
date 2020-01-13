using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Globe
{
    public static string nextSceneName;
}

public class AsyncLoadScene : MonoBehaviour
{
    public Text loadingText;
    public Image progressBar;
    public RectTransform rectTransform;
    public FadeInOut m_FadeInOut;
    private AsyncOperation operation;

    private float progressValue = 0f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScene")
        {
            //启动协程
            rectTransform.sizeDelta = new Vector2(Screen.width - 200, loadingText.rectTransform.sizeDelta.y);
            StartCoroutine(AsyncLoading());
        }
    }

    void Update()
    {
        //progress(0-1)的前0.9能够真实展现，但是只能使progress到达90%，isDone为true时才会继续加载0.9-1.0的这10%，但是当allowSceneActivation为trueis时才会使isDone为true，此时会自动转换场景 
        if (progressValue < 90)
        {
            progressValue = operation.progress * 100;
        }
        else
        {
            if(progressValue<100)
                progressValue++;
        }

        loadingText.text = progressValue + "%";//实时更新进度百分比的文本显示 

        progressBar.fillAmount = progressValue / 100f;//实时更新滑动进度图片的fillAmount值  

        if (progressValue == 100 && m_FadeInOut.isBlack == false)
        {
            loadingText.text = "按任意键继续";

            if (Input.anyKeyDown)
            {
                StartCoroutine(AllowLoading());
            }
        }
    }

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(Globe.nextSceneName);

        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;

        //保证别的地方也能控制场景切换的暂停
        yield return operation;
    }

    IEnumerator AllowLoading()
    {
        yield return StartCoroutine(m_FadeInOut.FadeIn());
        operation.allowSceneActivation = true;//启用自动加载场景  
    }
}
