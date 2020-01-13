using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSet : MonoBehaviour
{
    public RectTransform[] rectTransforms;
    public imageLocation[] imageLocations;

    public enum imageLocation
    {
        Top,Bottom,
    }

    void Start()
    {
        for(int i = 0;i<rectTransforms.Length;i++)
        {
            rectTransforms[i].sizeDelta = new Vector2(Screen.width, Screen.height / 5);
            if (imageLocations[i] == imageLocation.Bottom)
            {
                rectTransforms[i].position = new Vector2(Screen.width/2, -(Screen.height / 2)+ Screen.height /2);
            }
            if (imageLocations[i] == imageLocation.Top)
            {
                rectTransforms[i].position = new Vector2(0, Screen.height - (Screen.height / 10));
            }
        }
    }
}
