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
                    stageEditorBlocks.meleeNormal = true;
                    break;
                }

            case ("Ranged Normal"):
                {
                    stageEditorBlocks.rangedNormal = true;
                    break;
                }

            case ("Bottomless Pit"):
                {
                    stageEditorBlocks.bottomlessPit = true;
                    break;
                }

            case ("Player Spawn"):
                {
                    stageEditorBlocks.playerSpawn = true;
                    break;
                }

            case ("Enemy Spawn"):
                {
                    stageEditorBlocks.enemySpawn = true;
                    break;
                }

            case ("Drone Spawn"):
                {
                    stageEditorBlocks.enemyDroneSpawn = true;
                    break;
                }

            case ("Melee Restricted"):
                {
                    stageEditorBlocks.meleeRestricted = true;
                    break;
                }

            case ("Ranged Restricted"):
                {
                    stageEditorBlocks.rangedRestricted = true;
                    break;
                }

            case ("Melee Impassable"):
                {
                    stageEditorBlocks.meleeImpassable = true;
                    break;
                }

            case ("Ranged Camouflage"):
                {
                    stageEditorBlocks.rangedCamouflage = true;
                    break;
                }

            case ("Ranged Def Up"):
                {
                    stageEditorBlocks.rangedDefUp = true;
                    break;
                }

            case ("Melee Def Up"):
                {
                    stageEditorBlocks.meleeDefUp = true;
                    break;
                }

            case ("Ranged Regen"):
                {
                    stageEditorBlocks.rangedRegen = true;
                    break;
                }

            case ("Melee Regen"):
                {
                    stageEditorBlocks.meleeRegen = true;
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
