using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWallFade : MonoBehaviour
{
    public Renderer m_Renderer;
    public bool allowFade = false;
    public float diaphaneity = 1f;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if(allowFade)
        {
            if (diaphaneity > 0)
            {
                diaphaneity -= Time.deltaTime / 2;
                m_Renderer.material.color = new Color(m_Renderer.material.color.r, m_Renderer.material.color.g, m_Renderer.material.color.b, diaphaneity);
                if (Mathf.Approximately(diaphaneity, 0f))
                {
                    diaphaneity = 0f;
                    m_Renderer.enabled = false;
                    allowFade = false;
                }
            }
            else
            {
                diaphaneity = 0f;
                m_Renderer.enabled = false;
                allowFade = false;
            }
        }
    }
}
