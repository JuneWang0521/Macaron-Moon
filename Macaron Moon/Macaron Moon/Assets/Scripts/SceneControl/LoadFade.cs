using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFade : MonoBehaviour
{
    public FadeInOut m_FadeInOut;
    public bool allowFade = true;
    
    void Update()
    {
        if(allowFade)
        {
            StartCoroutine(m_FadeInOut.FadeOut());
            allowFade = false;
        }
    }
}
