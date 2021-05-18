using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacement : MonoBehaviour
{
    public StageGenerator stageGeneratorScene;

    private void Start()
    {
        this.transform.position = new Vector3(stageGeneratorScene.stageWidthEditor / 2, 8, -1.2f);
    }

    public void UpdateCameraPosition()
    {
        float camera_x = stageGeneratorScene.stageWidthEditor / 2;
        float camera_y = stageGeneratorScene.stageHeightEditor + 3;

        if (stageGeneratorScene.stageWidthEditor % 2 == 0)
        {
            this.transform.position = new Vector3(camera_x, camera_y, -1.2f);
        }

        else
        {
            this.transform.position = new Vector3(camera_x + 0.5f, camera_y, -1.2f);
        }
    }
}
