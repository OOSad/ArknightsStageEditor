using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceEditor : MonoBehaviour
{
    public GameObject generatorModeUICanvas;
    public StageEditorBlocks stageEditorBlocks;

    public void QueueUpSelectedTile(Dropdown dropdown)
    {
        switch (dropdown.options[dropdown.value].text)
        {
            case ("Melee Normal"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeNormalTile;
                    break;
                }

            case ("Ranged Normal"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedNormalTile;
                    break;
                }

            case ("Bottomless Pit"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.bottomlessPitTile;
                    break;
                }

            case ("Player Spawn"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.playerSpawnTile;
                    break;
                }

            case ("Enemy Spawn"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.enemySpawnTile;
                    break;
                }

            case ("Drone Spawn"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.enemyDroneSpawnTile;
                    break;
                }

            case ("Melee Restricted"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeRestrictedTile;
                    break;
                }

            case ("Ranged Restricted"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedRestrictedTile;
                    break;
                }

            case ("Melee Impassable"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeImpassableTile;
                    break;
                }

            case ("Ranged Camouflage"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedCamouflageTile;
                    break;
                }

            case ("Ranged Def Up"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedDefUpTile;
                    break;
                }

            case ("Melee Def Up"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeDefUpTile;
                    break;
                }

            case ("Ranged Regen"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedRegenTile;
                    break;
                }

            case ("Melee Regen"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeRegenTile;
                    break;
                }

            case ("Ranged Anti Air"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedAntiAirTile;
                    break;
                }

            case ("Melee Originium"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeOriginiumTile;
                    break;
                }

            case ("Ranged Ballista"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.rangedBallistaTile;
                    break;
                }

            case ("Melee Heat Pump"):
                {
                    stageEditorBlocks.currentlySelectedBlock = stageEditorBlocks.meleeHeatPumpTile;
                    break;
                }

            default: break;
        }
    }

    public void SwitchToGeneratorMode()
    {
        generatorModeUICanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
