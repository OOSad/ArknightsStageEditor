using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HigherGround : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material tileHighlighted;
    private Material tileDefault;

    private void Start()
    {
        tileDefault = this.GetComponent<Renderer>().material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Renderer>().material = tileHighlighted;
        Debug.Log("HigherGround " + this.GetComponent<StageEditor>().tileCoordinates[0] + " " + this.GetComponent<StageEditor>().tileCoordinates[1]);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Renderer>().material = tileDefault;
    }
}
