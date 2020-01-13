using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;

public class ImageLoading : MonoBehaviour
{
    public SetImageAlpha[] settings;
    public SetImageAlpha.FadeType[] fadeType;
    public ImageFadeAway imageFadeAway;
    public TextShow textShow;
    public PlayerControl playerControl;
    public float[] targetNumber;
    public float[] fadeSpeed;

    [HideInInspector]
    public int doneNum = 0;
    [HideInInspector]
    public bool doneLoading = false;
    [HideInInspector]
    public bool allowToShow = false;

    [HideInInspector]
    private int count = 0;

    void Start()
    {
        for (int i = 0; i < settings.Length; i++)
        {
            if (fadeType[i] == SetImageAlpha.FadeType.bottomY)
            {
                settings[i].bottomY = 1;
            }
            else if (fadeType[i] == SetImageAlpha.FadeType.leftX)
            {
                settings[i].leftX = 1;
            }
            else if (fadeType[i] == SetImageAlpha.FadeType.rightX)
            {
                settings[i].rightX = 1;
            }
            else if (fadeType[i] == SetImageAlpha.FadeType.topY)
            {
                settings[i].topY = 1;
            }
        }
    }

    void Update()
    {
        if(allowToShow && !imageFadeAway.allowToAway)
        {
            if (playerControl.allowToRun)
                playerControl.allowToRun = false;

            for (int i = 0; i < settings.Length; i++)
            {
                if (fadeType[i] == SetImageAlpha.FadeType.topY)
                {
                    if (settings[i].topY > targetNumber[i])
                    {
                        settings[i].topY -= Time.deltaTime / fadeSpeed[i];
                        if (settings[i].topY < targetNumber[i])
                        {
                            settings[i].topY = targetNumber[i];
                            doneNum++;
                        }
                    }
                }

                if (fadeType[i] == SetImageAlpha.FadeType.bottomY)
                {
                    if (settings[i].bottomY > targetNumber[i])
                    {
                        settings[i].bottomY -= Time.deltaTime / fadeSpeed[i];
                        if (settings[i].bottomY < targetNumber[i])
                        {
                            settings[i].bottomY = targetNumber[i];
                            doneNum++;
                        }
                    }
                }

                if (fadeType[i] == SetImageAlpha.FadeType.leftX)
                {
                    if (settings[i].leftX > targetNumber[i])
                    {
                        settings[i].leftX -= Time.deltaTime / 2;
                        if (settings[i].leftX < targetNumber[i])
                        {
                            settings[i].leftX = targetNumber[i];
                            doneNum++;
                        }
                    }
                }

                if (fadeType[i] == SetImageAlpha.FadeType.rightX)
                {
                    if (settings[i].rightX > targetNumber[i])
                    {
                        settings[i].rightX -= Time.deltaTime / 2;
                        if (settings[i].rightX < targetNumber[i])
                        {
                            settings[i].rightX = targetNumber[i];
                            doneNum++;
                        }
                    }
                }

            }
        }

        if (textShow.isPrint)
        {
            doneLoading = false;
        }

        if (doneNum == settings.Length && !textShow.isPrint)
        {
            count++;
            doneLoading = true;
            allowToShow = false;
            textShow.isPrint = true;
            textShow.StartEffect();
        }

        if(imageFadeAway.allowToAway)
        {
            doneNum = 0;
            textShow.isPrint = false;
        }
    }
}
