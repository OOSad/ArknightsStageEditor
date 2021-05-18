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


    //This is a different implementation of camera movement with acceleration and drift instead.
    //VERY fun to drag and slide the camera around like this, but not as practical as the raw Translate() method above.
    //I just couldn't bring myself to delete it!
    /*float acceleration = 0.0f;
    private void Update()
    {
        mouse = Mouse.current;

        if (mouse.rightButton.isPressed)
        {
            acceleration += mouse.delta.x.ReadValue() * 0.05f;
        }

        else
        {
            if (acceleration > 0.0f)
            {
                acceleration -= 0.05f;
            }

            else if (acceleration < 0.0f)
            {
                acceleration += 0.05f;
            }
        }

        this.transform.Translate((acceleration * -1) * Time.deltaTime, 0, 0);
    }*/
}
