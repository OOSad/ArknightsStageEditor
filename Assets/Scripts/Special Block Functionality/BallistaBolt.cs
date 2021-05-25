using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaBolt : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyBolt", 1.0f);
    }

    void Update()
    {
        ShootBoltForward();
    }

    private void DestroyBolt()
    {
        Destroy(this.gameObject);
    }

    private void ShootBoltForward()
    {
        this.transform.localPosition += new Vector3(0, 0, 0.5f);
    }
}
