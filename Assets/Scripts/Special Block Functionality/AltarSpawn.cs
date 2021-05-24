using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarSpawn : MonoBehaviour
{
    public GameObject frostAltarEffect;

    private void Start()
    {
        InvokeRepeating("SpawnFrostEffect", 10.0f, 10.0f);
    }

    private void SpawnFrostEffect()
    {
        Instantiate(frostAltarEffect, this.gameObject.transform);
    }
}
