using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaBoltShooter : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyBolt", 3.0f);
    }

    void Update()
    {
        this.transform.localPosition += new Vector3(0, 0, 0.5f);             
    }

    private void DestroyBolt()
    {
        Destroy(this.gameObject);
    }
}
