using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextControl : MonoBehaviour
{
    public Text[] texts;
    public Text zeroText;
    public ImageLoading imageLoading;
    public ImageFadeAway imageFadeAway;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < texts.Length; i++)
        {
            texts[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(imageLoading.doneLoading)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].enabled = true;
            }
        }

        if(imageFadeAway.allowToAway)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].enabled = false;
            }

            zeroText.text = "";
        }
    }
}
