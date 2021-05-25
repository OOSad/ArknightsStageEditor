using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarTile : MonoBehaviour
{
    public GameObject altarAoE;

    private void Start()
    {
        InvokeRepeating("SpawnAltarAoE", 10.0f, 10.0f);
    }

    private void SpawnAltarAoE()
    {
        Instantiate(altarAoE, this.gameObject.transform);
    }
}
