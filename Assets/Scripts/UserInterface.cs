using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public GameObject stageGenerator;

    public InputField stageWidthField;
    public InputField stageHeightField;


    private void Start()
    {
        // Update UI elements after the program has had a moment to load.
        Invoke("UpdateUIInputFields", 0.5f);
    }

    private void Update()
    {
        
    }

    private void UpdateUIInputFields()
    {
        stageWidthField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().stageWidthEditor);
        stageHeightField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().stageHeightEditor);
    }

    public void UpdateEditorValues()
    {
        if (Convert.ToInt32(stageWidthField.text) > 11)
        {
            stageWidthField.text = Convert.ToString(11);
        }

        if (Convert.ToInt32(stageHeightField.text) > 7)
        {
            stageHeightField.text = Convert.ToString(7);
        }

        stageGenerator.GetComponent<StageGenerator>().stageWidthEditor = Convert.ToInt32(stageWidthField.text);
        stageGenerator.GetComponent<StageGenerator>().stageHeightEditor = Convert.ToInt32(stageHeightField.text);
    }
}
