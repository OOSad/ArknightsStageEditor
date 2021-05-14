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
    public InputField numberOfHigherGroundTilesField;
    public InputField numberOfBottomlessPitsField;
    public InputField numberOfPlayerSpawnsField;
    public InputField numberOfEnemySpawnsField;


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
        numberOfHigherGroundTilesField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfHigherGroundTilesEditor);
        numberOfBottomlessPitsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfBottomlessPitsEditor);
        numberOfPlayerSpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfPlayerSpawnsEditor);
        numberOfEnemySpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfEnemySpawnsEditor);
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
        stageGenerator.GetComponent<StageGenerator>().numberOfHigherGroundTilesEditor = Convert.ToInt32(numberOfHigherGroundTilesField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfBottomlessPitsEditor = Convert.ToInt32(numberOfBottomlessPitsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfPlayerSpawnsEditor = Convert.ToInt32(numberOfPlayerSpawnsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfEnemySpawnsEditor = Convert.ToInt32(numberOfEnemySpawnsField.text);

    }
}
