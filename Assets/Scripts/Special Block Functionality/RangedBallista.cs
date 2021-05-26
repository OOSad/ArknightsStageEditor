using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBallista : MonoBehaviour
{
    public GameObject ballistaBolt;

    void Start()
    {
        RotateThisObjectRandomlyOnStart(this.gameObject);
        InvokeRepeating("CreateBallistaBolt", 3.0f, 3.0f);
    }

    private void CreateBallistaBolt()
    {
        Instantiate(ballistaBolt, this.gameObject.transform);
    }

    private void RotateThisObjectRandomlyOnStart(GameObject thisGameObject)
    {
        switch (Random.Range(1, 4))
        {
            case 1: break;
            case 2: thisGameObject.transform.Rotate(0, 90, 0); break;
            case 3: thisGameObject.transform.Rotate(0, 180, 0); break;
            case 4: thisGameObject.transform.Rotate(0, 270, 0); break;
            default: break;
        }
    }
}
