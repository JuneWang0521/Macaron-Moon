using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    public SpriteRenderer m_TalkImage;
    public ImageLoading imageLoading;
    public ImageFadeAway imageFadeAway;
    public TextShow textShow;
    public Text m_sName;
    private TalkControl talkControl;

    public string[] m_strings;
    public string[] m_speakers;
    public string triggerName;
    private int pressCount = 0;

    void Start()
    {
        talkControl = GameObject.Find("TalkControl").GetComponent<TalkControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        m_TalkImage.enabled = true;
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(pressCount <m_strings.Length)
            {
                textShow.setWords(m_strings[pressCount]);
                m_sName.text = m_speakers[pressCount];
                if (pressCount == 0)
                    imageLoading.allowToShow = true;
                pressCount++;
            }
            else
            {
                pressCount = 0;
                imageFadeAway.allowToAway = true;
                talkControl.CheckTalkState(triggerName);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        m_TalkImage.enabled = false;
    }
}
