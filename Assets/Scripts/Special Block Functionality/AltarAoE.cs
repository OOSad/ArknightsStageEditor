using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarAoE : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }

    private void Update()
    {
        if (this.transform.localScale.x < 1.0f)
        {
            this.transform.localScale += new Vector3(5.0f * Time.deltaTime, 5.0f * Time.deltaTime, 5.0f * Time.deltaTime);
        }
    }

}
