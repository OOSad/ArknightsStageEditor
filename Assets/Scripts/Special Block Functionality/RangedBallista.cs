using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBallista : MonoBehaviour
{
    public GameObject ballistaBolt;

    void Start()
    {
        switch(Random.Range(1, 4))
        {
            case 1: break;
            case 2: this.transform.Rotate(0, 90, 0); break;
            case 3: this.transform.Rotate(0, 180, 0); break;
            case 4: this.transform.Rotate(0, 270, 0); break;
            default: break;
        }

        InvokeRepeating("CreateBallistaBolt", 3.0f, 3.0f);
    }

    private void CreateBallistaBolt()
    {
        Instantiate(ballistaBolt, this.gameObject.transform);
    }
}
