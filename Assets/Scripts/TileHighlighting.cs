using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileHighlighting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material tileHighlighted;

    private List<Renderer> rendererList = new List<Renderer>();
    private List<Material> materialDefaultList = new List<Material>();

    private void Start()
    {
        rendererList.Add(this.transform.GetComponent<Renderer>());

        for (int i = 0; i < this.transform.childCount; i++)
        {
            rendererList.Add(this.transform.GetChild(i).GetComponent<Renderer>());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < rendererList.Count; i++)
        {
            materialDefaultList.Add(rendererList[i].material);
        }

        for (int i = 0; i < rendererList.Count; i++)
        {
            rendererList[i].material = tileHighlighted;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < rendererList.Count; i++)
        {
            rendererList[i].material = materialDefaultList[i];
        }
    }

}
