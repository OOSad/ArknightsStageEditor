using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlacement : MonoBehaviour
{
    public StageGenerator stageGenerator;

    private void Start()
    {
        PositionCameraAboveStageAtStart();
    }

    public void PositionCameraAboveStageAtStart()
    {
        this.transform.position = new Vector3(stageGenerator.stageWidthEditor / 2, 8, -1.2f);
    }

    public void UpdateCameraPosition()
    {
        float camera_x = stageGenerator.stageWidthEditor / 2;
        float camera_y = stageGenerator.stageHeightEditor + 2;

        if (stageGenerator.stageWidthEditor % 2 == 0)
        {
            this.transform.position = new Vector3(camera_x, camera_y, -1.2f);
        }

        else
        {
            this.transform.position = new Vector3(camera_x + 0.5f, camera_y, -1.2f);
        }
    }

}
