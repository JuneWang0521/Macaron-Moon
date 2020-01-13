using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShine : MonoBehaviour
{
    public Light m_Light;
    public LightControl lightControl;
    public float targetIntensity;

    void Start()
    {
        m_Light.intensity = 0f;
    }

    void Update()
    {
        if (lightControl.allowToShine)
        {
            if (m_Light.intensity < targetIntensity)
            {
                m_Light.intensity += Time.deltaTime/1.5f;
                //if (Mathf.Approximately(m_Light.intensity, targetIntensity))
                //{
                //    m_Light.intensity = targetIntensity;
                //    lightControl.allowToShine = false;
                //}
            }
            else
            {
                m_Light.intensity = targetIntensity;
                lightControl.allowToShine = false;
            }
        }
    }
}
