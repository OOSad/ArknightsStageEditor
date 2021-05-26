using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPanning : MonoBehaviour
{
    private Mouse mouse;

    private void Update()
    {
        mouse = Mouse.current;

        if (mouse.rightButton.isPressed)
        {
            PanCameraLeftOrRight(mouse.delta.x.ReadValue());
        }
    }

    private void PanCameraLeftOrRight(float mouse_delta_x_axis)
    {
        this.transform.Translate((mouse_delta_x_axis * -1) * Time.deltaTime, 0, 0);
    }
}
