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
            this.transform.Translate((mouse.delta.x.ReadValue() * -1) * Time.deltaTime, 0, 0);
        }
    }
}
