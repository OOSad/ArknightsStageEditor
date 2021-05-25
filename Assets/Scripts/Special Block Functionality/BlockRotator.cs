using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class BlockRotator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Mouse mouse;

    private bool mouseIsOverTile = false;

    void Update()
    {
        // Must fetch mouse on Update instead of Start or OnEnable else the entire program crashes for some reason.
        // This only seems to happen after building and running on the WebGL player.
        mouse = Mouse.current;

        if (mouseIsOverTile == true && mouse.scroll.y.ReadValue() > 0)
        {
            this.gameObject.transform.Rotate(0, 90, 0);
        }

        if (mouseIsOverTile == true && mouse.scroll.y.ReadValue() < 0)
        {
            this.gameObject.transform.Rotate(0, -90, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsOverTile = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseIsOverTile = false;
    }
}
