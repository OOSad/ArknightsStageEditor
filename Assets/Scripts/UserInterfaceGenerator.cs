using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceGenerator : MonoBehaviour
{
    public StageGenerator stageGenerator;

    public InputField stageWidthField;
    public InputField stageHeightField;
    public InputField numberOfRangedNormalField;
    public InputField numberOfBottomlessPitsField;
    public InputField numberOfPlayerSpawnsField;
    public InputField numberOfEnemySpawnsField;
    public InputField numberOfEnemyDroneSpawnsField;
    public InputField numberOfMeleeRestrictedField;
    public InputField numberOfRangedRestrictedField;
    public InputField numberOfMeleeImpassableField;
    public InputField numberOfRangedCamouflageField;
    public InputField numberOfRangedDefUpField;
    public InputField numberOfMeleeDefUpField;
    public InputField numberOfRangedRegenField;
    public InputField numberOfMeleeRegenField;
    public InputField numberOfRangedAntiAirField;
    public InputField numberOfMeleeOriginiumField;
    public InputField numberOfRangedBallistaField;
    public InputField numberOfMeleeHeatPumpsField;
    public InputField numberOfRangedFrostAltarField;
    public InputField numberOfRangedOriginiumAltarField;

    public GameObject editorModeUICanvas;


    private void Start()
    {
        // Update UI elements after the program has had a moment to load.
        // (program will throw up some errors otherwise)
        Invoke("UpdateUIInputFields", 0.5f);
    }

    private void UpdateUIInputFields()
    {
        stageWidthField.text = Convert.ToString(stageGenerator.stageWidthEditor);
        stageHeightField.text = Convert.ToString(stageGenerator.stageHeightEditor);
        numberOfRangedNormalField.text = Convert.ToString(stageGenerator.numberOfRangedNormalTilesEditor);
        numberOfBottomlessPitsField.text = Convert.ToString(stageGenerator.numberOfBottomlessPitsEditor);
        numberOfPlayerSpawnsField.text = Convert.ToString(stageGenerator.numberOfPlayerSpawnsEditor);
        numberOfEnemySpawnsField.text = Convert.ToString(stageGenerator.numberOfEnemySpawnsEditor);
        numberOfEnemyDroneSpawnsField.text = Convert.ToString(stageGenerator.numberOfEnemyDroneSpawnsEditor);
        numberOfMeleeRestrictedField.text = Convert.ToString(stageGenerator.numberOfMeleeRestrictedEditor);
        numberOfRangedRestrictedField.text = Convert.ToString(stageGenerator.numberOfRangedRestrictedEditor);
        numberOfMeleeImpassableField.text = Convert.ToString(stageGenerator.numberOfMeleeImpassableEditor);
        numberOfRangedCamouflageField.text = Convert.ToString(stageGenerator.numberOfRangedCamouflageTilesEditor);
        numberOfRangedDefUpField.text = Convert.ToString(stageGenerator.numberOfRangedDefUpTilesEditor);
        numberOfMeleeDefUpField.text = Convert.ToString(stageGenerator.numberOfMeleeDefUpTilesEditor);
        numberOfRangedRegenField.text = Convert.ToString(stageGenerator.numberOfRangedRegenTilesEditor);
        numberOfMeleeRegenField.text = Convert.ToString(stageGenerator.numberOfMeleeRegenTilesEditor);
        numberOfRangedAntiAirField.text = Convert.ToString(stageGenerator.numberOfRangedAntiAirTilesEditor);
        numberOfMeleeOriginiumField.text = Convert.ToString(stageGenerator.numberOfMeleeOriginiumTilesEditor);
        numberOfRangedBallistaField.text = Convert.ToString(stageGenerator.numberOfRangedBallistaTilesEditor);
        numberOfMeleeHeatPumpsField.text = Convert.ToString(stageGenerator.numberOfMeleeHeatPumpTilesEditor);
        numberOfRangedFrostAltarField.text = Convert.ToString(stageGenerator.numberOfRangedFrostAltarTilesEditor);
        numberOfRangedOriginiumAltarField.text = Convert.ToString(stageGenerator.numberOfRangedOriginiumAltarTilesEditor);
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

        stageGenerator.stageWidthEditor = Convert.ToInt32(stageWidthField.text);
        stageGenerator.stageHeightEditor = Convert.ToInt32(stageHeightField.text);
        stageGenerator.numberOfRangedNormalTilesEditor = Convert.ToInt32(numberOfRangedNormalField.text);
        stageGenerator.numberOfBottomlessPitsEditor = Convert.ToInt32(numberOfBottomlessPitsField.text);
        stageGenerator.numberOfPlayerSpawnsEditor = Convert.ToInt32(numberOfPlayerSpawnsField.text);
        stageGenerator.numberOfEnemySpawnsEditor = Convert.ToInt32(numberOfEnemySpawnsField.text);
        stageGenerator.numberOfEnemyDroneSpawnsEditor = Convert.ToInt32(numberOfEnemyDroneSpawnsField.text);
        stageGenerator.numberOfMeleeRestrictedEditor = Convert.ToInt32(numberOfMeleeRestrictedField.text);
        stageGenerator.numberOfRangedRestrictedEditor = Convert.ToInt32(numberOfRangedRestrictedField.text);
        stageGenerator.numberOfMeleeImpassableEditor = Convert.ToInt32(numberOfMeleeImpassableField.text);
        stageGenerator.numberOfRangedCamouflageTilesEditor = Convert.ToInt32(numberOfRangedCamouflageField.text);
        stageGenerator.numberOfRangedDefUpTilesEditor = Convert.ToInt32(numberOfRangedDefUpField.text);
        stageGenerator.numberOfMeleeDefUpTilesEditor = Convert.ToInt32(numberOfMeleeDefUpField.text);
        stageGenerator.numberOfRangedRegenTilesEditor = Convert.ToInt32(numberOfRangedRegenField.text);
        stageGenerator.numberOfMeleeRegenTilesEditor = Convert.ToInt32(numberOfMeleeRegenField.text);
        stageGenerator.numberOfRangedAntiAirTilesEditor = Convert.ToInt32(numberOfRangedAntiAirField.text);
        stageGenerator.numberOfMeleeOriginiumTilesEditor = Convert.ToInt32(numberOfMeleeOriginiumField.text);
        stageGenerator.numberOfRangedBallistaTilesEditor = Convert.ToInt32(numberOfRangedBallistaField.text);
        stageGenerator.numberOfMeleeHeatPumpTilesEditor = Convert.ToInt32(numberOfMeleeHeatPumpsField.text);
        stageGenerator.numberOfRangedFrostAltarTilesEditor = Convert.ToInt32(numberOfRangedFrostAltarField.text);
        stageGenerator.numberOfRangedOriginiumAltarTilesEditor = Convert.ToInt32(numberOfRangedOriginiumAltarField.text);
    }

    public void SwitchToEditorMode()
    {
        editorModeUICanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
