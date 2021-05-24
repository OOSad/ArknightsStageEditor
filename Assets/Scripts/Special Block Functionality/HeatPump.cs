using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatPump : MonoBehaviour
{
    private Material material;
    
    private float increment = 0.00f;
    private bool turnUpTheHeat = false;
    private bool turnDownTheHeat = false;

    private void Start()
    {
        material = this.GetComponent<Renderer>().material;

        InvokeRepeating("TurnUpTheHeat", Random.Range(8.0f, 12.0f), Random.Range(8.0f, 12.0f));
    }

    private void Update()
    {
        material.SetColor("_EmissionColor", Color.Lerp(Color.black, Color.red, increment));

        if (turnUpTheHeat)
        {
            increment += 4.0f * Time.deltaTime;
        }

        if (turnDownTheHeat)
        {
            increment -= 1.0f * Time.deltaTime;
        }

        if (increment > 1.0f)
        {
            increment = 1.0f;
            turnUpTheHeat = false;
            TurnDownTheHeat();
        }

        if (increment < 0.0f)
        {
            increment = 0.0f;
            turnDownTheHeat = false;
        }
    }

    private void TurnUpTheHeat()
    {
        turnUpTheHeat = true;
    }

    private void TurnDownTheHeat()
    {
        turnDownTheHeat = true;
    }

}
