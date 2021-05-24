using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileHighlighting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material tileHighlighted;
    private Material tileDefault;

    private void Start()
    {
        try
        {
            tileDefault = this.GetComponent<Renderer>().material;
        }

        catch (MissingComponentException)
        {
            tileDefault = this.GetComponentInChildren<Renderer>().material;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        try
        {
            this.GetComponent<Renderer>().material = tileHighlighted;
        }

        catch (MissingComponentException)
        {
            this.GetComponentInChildren<Renderer>().material = tileHighlighted;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        try
        {
            this.GetComponent<Renderer>().material = tileDefault;
        }

        catch (MissingComponentException)
        {
            this.GetComponentInChildren<Renderer>().material = tileDefault;
        }
    }
}
