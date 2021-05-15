using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlidingPanel : MonoBehaviour
{
    private Mouse mouse = Mouse.current;
    public RectTransform rectTransform;

    public int scrollLimit = 300;

    private void Update()
    {
        if (rectTransform.anchoredPosition.x > scrollLimit)
        {
            rectTransform.anchoredPosition = new Vector3(scrollLimit, 4, 0);
        }

        if (rectTransform.anchoredPosition.x < scrollLimit * -1)
        {
            rectTransform.anchoredPosition = new Vector3((scrollLimit * -1), 4, 0);
        }
    }

    public void SlideThePanel()
    {
        this.transform.Translate(mouse.delta.x.ReadValue() * Time.deltaTime, 0, 0);
    }
}
