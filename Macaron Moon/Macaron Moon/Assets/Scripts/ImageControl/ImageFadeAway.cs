using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImageFadeAway : MonoBehaviour
{
    public SetImageAlpha[] settings;
    public SetImageAlpha.FadeType[] fadeType;
    public ImageLoading imageLoading;
    public PlayerControl playerControl;
    public float[] fadeSpeed;

    [HideInInspector]
    public int doneNum = 0;
    [HideInInspector]
    public bool doneLoading = false;
    [HideInInspector]
    public bool allowToAway = false;

    void Update()
    {
        if (allowToAway && !imageLoading.allowToShow)
        {
            for (int i = 0; i < settings.Length; i++)
            {
                if (fadeType[i] == SetImageAlpha.FadeType.topY)
                {
                    if (settings[i].topY < 1)
                    {
                        settings[i].topY += Time.deltaTime / fadeSpeed[i];
                        //settings[i].topY -= Time.deltaTime / 2;
                        if (settings[i].topY > 1)
                        {
                            settings[i].topY = 1;
                            doneNum++;
                        }
                    }
                }

                if (fadeType[i] == SetImageAlpha.FadeType.bottomY)
                {
                    if (settings[i].bottomY < 1)
                    {
                        settings[i].bottomY += Time.deltaTime / fadeSpeed[i];
                        if (settings[i].bottomY > 1)
                        {
                            settings[i].bottomY = 1;
                            doneNum++;
                        }
                    }
                }

                if (fadeType[i] == SetImageAlpha.FadeType.leftX)
                {
                    if (settings[i].leftX  < 1)
                    {
                        settings[i].leftX += Time.deltaTime / 2;
                        if (settings[i].leftX > 1)
                        {
                            settings[i].leftX = 1;
                            doneNum++;
                        }
                    }
                }

                if (fadeType[i] == SetImageAlpha.FadeType.rightX)
                {
                    if (settings[i].rightX <1)
                    {
                        settings[i].rightX -= Time.deltaTime / 2;
                        if (settings[i].rightX > 1)
                        {
                            settings[i].rightX = 1;
                            doneNum++;
                        }
                    }
                }

            }
        }

        if (doneNum == settings.Length)
        {
            doneLoading = true;
            allowToAway = false;
            if (!playerControl.allowToRun)
                playerControl.allowToRun = true;
        }

        if(imageLoading.allowToShow)
        {
            doneLoading = false;
            doneNum = 0;
        }
    }
}
