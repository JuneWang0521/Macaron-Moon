using System.Collections;
using UnityEngine;
using UnityEngine.UI;//注意添加RawImage命名空间

public class FadeInOut : MonoBehaviour
{
    [HideInInspector]
    public bool isBlack = false;//是否完全变黑
    [HideInInspector]
    public float fadeSpeed = 5f;//透明度变化速率

    public RawImage rawImage;
    public RectTransform rectTransform;
    public static FadeType fadeType;

    public enum FadeType
    {
        FadeIn,FadeOut,
    }

    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);//使背景满屏
        rawImage.color = Color.clear;
    }

    public bool GetBlack()
    {
        return isBlack;
    }

    public IEnumerator Fade()
    {
        if (fadeType == FadeType.FadeOut)
        {
            yield return StartCoroutine(FadeOut());
        }
        else if (fadeType == FadeType.FadeIn)
        {
            yield return StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeIn()
    {
        while (true)
        {
            if(rawImage.color != Color.black)
            {
                rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);//渐暗

                yield return new WaitForSeconds(0.001f);
            }

            if (rawImage.color.a > 0.9f)
            {
                rawImage.color = Color.black;
                isBlack = true;
                break;
            }
        }
        yield return null;
    }

    public IEnumerator FadeOut()
    {
        rawImage.color = Color.black;
        isBlack = true;

        while (true)
        {
            if(rawImage.color != Color.clear)
            {
                rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);//渐亮

                //Debug.Log(rawImage.color.a);//debug

                yield return new WaitForSeconds(0.001f);
            }

            if (rawImage.color.a < 0.1f)
            {
                rawImage.color = Color.clear;
                isBlack = false;
                break;
            }
        }
        yield return null;
    }
}