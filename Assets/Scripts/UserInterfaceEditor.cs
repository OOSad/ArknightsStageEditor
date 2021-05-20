using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceEditor : MonoBehaviour
{
    public GameObject generatorModeUICanvas;

    public void QueueUpSelectedTile(Dropdown dropdown)
    {
        switch (dropdown.options[dropdown.value].text)
        {
            case ("Melee Normal"):
                {
                    QueueUpMeleeNormalTile();
                    break;
                }

            case ("Ranged Normal"):
                {
                    QueueUpRangedNormalTile();
                    break;
                }

            case ("Bottomless Pit"):
                {
                    QueueUpBottomlessPitTile();
                    break;
                }

            case ("Player Spawn"):
                {
                    QueueUpPlayerSpawnTile();
                    break;
                }

            case ("Enemy Spawn"):
                {
                    QueueUpEnemySpawnTile();
                    break;
                }

            case ("Drone Spawn"):
                {
                    QueueUpEnemyDroneSpawnTile();
                    break;
                }

            case ("Melee Restricted"):
                {
                    QueueUpMeleeRestrictedTile();
                    break;
                }

            case ("Ranged Restricted"):
                {
                    QueueUpRangedRestrictedTile();
                    break;
                }

            case ("Melee Impassable"):
                {
                    QueueUpMeleeImpassableTile();
                    break;
                }

            case ("Ranged Camouflage"):
                {
                    QueueUpRangedCamouflageTile();
                    break;
                }

            default: break;
        }
    }

    public void QueueUpMeleeNormalTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeNormal = true;
    }

    public void QueueUpRangedNormalTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedNormal = true;
    }

    public void QueueUpBottomlessPitTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().bottomlessPit = true;
    }

    public void QueueUpPlayerSpawnTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().playerSpawn = true;
    }

    public void QueueUpEnemySpawnTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().enemySpawn = true;
    }

    public void QueueUpEnemyDroneSpawnTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().enemyDroneSpawn = true;
    }

    public void QueueUpMeleeRestrictedTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeRestricted = true;
    }

    public void QueueUpRangedRestrictedTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedRestricted = true;
    }

    public void QueueUpMeleeImpassableTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeImpassable = true;
    }

    public void QueueUpRangedCamouflageTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedCamouflage = true;
    }



    public void SwitchToGeneratorMode()
    {
        generatorModeUICanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
