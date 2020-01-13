using UnityEngine;

public class TestFade : MonoBehaviour
{
    public FadeInOut m_Fade;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(m_Fade.FadeOut());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(m_Fade.FadeIn());
        }
    }
}
