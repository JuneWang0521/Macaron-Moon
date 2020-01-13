using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    public ImageLoading imageLoading;
    public float charsPerSecond = 0.05f;//打字时间间隔
    private string words;//保存需要显示的文字

    private bool isActive = false;
    private float timer;//计时器
    private Text myText;
    private int currentPos = 0;//当前打字位置

    [HideInInspector]
    public bool isPrint = false;    //是否完成打字

    void Start()
    {
        timer = 0;
        isActive = true;
        myText = GetComponent<Text>();
        words = myText.text;
        myText.text = "";//获取Text的文本信息，保存到words中，然后动态更新文本显示内容，实现打字机的效果
    }

    void Update()
    {
        if (isPrint)
        {
            OnStartWriter();
        }
    }

    public void setWords(string str)
    {
        if (str != words)
        {
            words = str;
            timer = 0;
            currentPos = 0;
            StartEffect();
            isPrint = false;
        }
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// 执行打字任务
    /// </summary>
    public void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判断计时器时间是否到达
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//刷新文本显示内容

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }
        }
    }
    /// <summary>
    /// 结束打字，初始化数据
    /// </summary>
    void OnFinish()
    {
        isPrint = true;
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }
}
