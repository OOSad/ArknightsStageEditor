using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacement : MonoBehaviour
{
    private void Update()
    {
        int stageWidthEditor = GameObject.FindGameObjectWithTag("StageGenerator").GetComponent<StageGenerator>().stageWidthEditor;

        this.transform.position = new Vector3 (stageWidthEditor / 2, 7, -0.6f);
    }
}
