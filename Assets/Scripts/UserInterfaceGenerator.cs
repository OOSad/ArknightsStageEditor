using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceGenerator : MonoBehaviour
{
    public GameObject stageGenerator;

    public InputField stageWidthField;
    public InputField stageHeightField;
    public InputField numberOfHigherGroundTilesField;
    public InputField numberOfBottomlessPitsField;
    public InputField numberOfPlayerSpawnsField;
    public InputField numberOfEnemySpawnsField;
    public InputField numberOfEnemyDroneSpawnsField;
    public InputField numberOfGroundTilesRestrictedField;
    public InputField numberOfRangedTilesRestrictedField;
    public InputField numberOfGroundTilesImpassableField;
    public InputField numberOfRangedCamouflageField;

    public GameObject editorModeUICanvas;


    private void Start()
    {
        // Update UI elements after the program has had a moment to load.
        // (program will throw up some errors otherwise)
        Invoke("UpdateUIInputFields", 0.5f);
    }

    private void UpdateUIInputFields()
    {
        stageWidthField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().stageWidthEditor);
        stageHeightField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().stageHeightEditor);
        numberOfHigherGroundTilesField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfRangedNormalTilesEditor);
        numberOfBottomlessPitsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfBottomlessPitsEditor);
        numberOfPlayerSpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfPlayerSpawnsEditor);
        numberOfEnemySpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfEnemySpawnsEditor);
        numberOfEnemyDroneSpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfEnemyDroneSpawnsEditor);
        numberOfGroundTilesRestrictedField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfMeleeRestrictedEditor);
        numberOfRangedTilesRestrictedField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfRangedRestrictedEditor);
        numberOfGroundTilesImpassableField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfMeleeImpassableEditor);
        numberOfRangedCamouflageField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfRangedCamouflageTilesEditor);
    }

    public void UpdateEditorValues()
    {
        if (Convert.ToInt32(stageWidthField.text) > 22)
        {
            stageWidthField.text = Convert.ToString(22);
        }

        if (Convert.ToInt32(stageHeightField.text) > 16)
        {
            stageHeightField.text = Convert.ToString(16);
        }

        if (Convert.ToInt32(stageWidthField.text) < 7)
        {
            stageWidthField.text = Convert.ToString(7);
        }

        if (Convert.ToInt32(stageHeightField.text) < 4)
        {
            stageHeightField.text = Convert.ToString(4);
        }

        stageGenerator.GetComponent<StageGenerator>().stageWidthEditor = Convert.ToInt32(stageWidthField.text);
        stageGenerator.GetComponent<StageGenerator>().stageHeightEditor = Convert.ToInt32(stageHeightField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfRangedNormalTilesEditor = Convert.ToInt32(numberOfHigherGroundTilesField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfBottomlessPitsEditor = Convert.ToInt32(numberOfBottomlessPitsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfPlayerSpawnsEditor = Convert.ToInt32(numberOfPlayerSpawnsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfEnemySpawnsEditor = Convert.ToInt32(numberOfEnemySpawnsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfEnemyDroneSpawnsEditor = Convert.ToInt32(numberOfEnemyDroneSpawnsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfMeleeRestrictedEditor = Convert.ToInt32(numberOfGroundTilesRestrictedField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfRangedRestrictedEditor = Convert.ToInt32(numberOfRangedTilesRestrictedField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfMeleeImpassableEditor = Convert.ToInt32(numberOfGroundTilesImpassableField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfRangedCamouflageTilesEditor = Convert.ToInt32(numberOfRangedCamouflageField.text);
    }

    public void SwitchToEditorMode()
    {
        editorModeUICanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
