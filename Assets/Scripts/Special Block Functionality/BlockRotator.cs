using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class BlockRotator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Mouse mouse;
    private bool canRotate = false;

    void Update()
    {
        mouse = Mouse.current;

        if (mouse.scroll.y.ReadValue() != 0 && canRotate == true)
        {
            this.gameObject.transform.Rotate(0, 90, 0);
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canRotate = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canRotate = false;
    }
}
