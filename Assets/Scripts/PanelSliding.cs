using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PanelSliding : MonoBehaviour, IDragHandler
{
    private Mouse mouse;

    private int minScrollValue = -178;

    private void Update()
    {
        // Must fetch mouse on Update instead of Start or OnEnable else the entire program crashes for some reason.
        // This only seems to happen after building and running on the WebGL player.

        mouse = Mouse.current;

        if (this.GetComponent<RectTransform>().localPosition.y < minScrollValue)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, minScrollValue, this.transform.localPosition.z);
        }

        if (this.GetComponent<RectTransform>().localPosition.y > (minScrollValue * -1))
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, (minScrollValue * -1), this.transform.localPosition.z);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.localPosition += new Vector3(0, mouse.delta.y.ReadValue(), 0);
    }
}
