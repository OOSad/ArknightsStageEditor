using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorRaycasting : MonoBehaviour
{
    private void Start()
    {
        AddPhysicsRaycaster();
    }

    private void AddPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
        
    }
}
