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
    public InputField numberOfGroundTilesRestricted;
    public InputField numberOfRangedTilesRestricted;
    public InputField numberOfGroundTilesImpassable;

    public Toggle playerSpawnOutside;

    public GameObject editorModeUICanvas;


    private void Start()
    {
        // Update UI elements after the program has had a moment to load.
        Invoke("UpdateUIInputFields", 0.5f);
    }

    private void UpdateUIInputFields()
    {
        stageWidthField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().stageWidthEditor);
        stageHeightField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().stageHeightEditor);
        numberOfHigherGroundTilesField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfHigherGroundTilesEditor);
        numberOfBottomlessPitsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfBottomlessPitsEditor);
        numberOfPlayerSpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfPlayerSpawnsEditor);
        numberOfEnemySpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfEnemySpawnsEditor);
        numberOfEnemyDroneSpawnsField.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfEnemyDroneSpawnsEditor);
        numberOfGroundTilesRestricted.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfLowerGroundRestrictedEditor);
        numberOfRangedTilesRestricted.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfHigherGroundRestrictedEditor);
        numberOfGroundTilesImpassable.text = Convert.ToString(stageGenerator.GetComponent<StageGenerator>().numberOfLowerGroundImpassableEditor);
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
        stageGenerator.GetComponent<StageGenerator>().numberOfEnemyDroneSpawnsEditor = Convert.ToInt32(numberOfEnemyDroneSpawnsField.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfLowerGroundRestrictedEditor = Convert.ToInt32(numberOfGroundTilesRestricted.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfHigherGroundRestrictedEditor = Convert.ToInt32(numberOfRangedTilesRestricted.text);
        stageGenerator.GetComponent<StageGenerator>().numberOfLowerGroundImpassableEditor = Convert.ToInt32(numberOfGroundTilesImpassable.text);

    }


    public void TogglePlayerSpawnsOnOutside(Toggle playerSpawnOutsideToggle)
    {
        if (playerSpawnOutsideToggle.isOn)
        {
            stageGenerator.GetComponent<StageGenerator>().playerSpawnOnOutside = true;
        }

        else
        {
            stageGenerator.GetComponent<StageGenerator>().playerSpawnOnOutside = false;
        }
    }

    public void ToggleEnemySpawnsOnOutside(Toggle enemySpawnOutsideToggle)
    {
        if (enemySpawnOutsideToggle.isOn)
        {
            stageGenerator.GetComponent<StageGenerator>().enemySpawnOnOutside = true;
        }

        else
        {
            stageGenerator.GetComponent<StageGenerator>().enemySpawnOnOutside = false;
        }
    }

    public void SwitchToEditorMode()
    {
        editorModeUICanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
