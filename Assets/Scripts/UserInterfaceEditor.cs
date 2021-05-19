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
            case ("Melee Tile"):
                {
                    QueueUpLowerGroundTile();
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

            case ("Melee Restricted"):
                {
                    QueueUpLowerGroundRestrictedTile();
                    break;
                }

            case ("Ranged Restricted"):
                {
                    QueueUpHigherGroundRestrictedTile();
                    break;
                }

            case ("Melee Impassable"):
                {
                    QueueUpLowerGroundImpassableTile();
                    break;
                }

            case ("Drone Spawn"):
                {
                    QueueUpEnemyDroneSpawnTile();
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

    public void QueueUpLowerGroundTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().lowerGround = true;
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

    public void QueueUpLowerGroundRestrictedTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().lowerRestricted = true;
    }

    public void QueueUpHigherGroundRestrictedTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().higherRestricted = true;
    }

    public void QueueUpLowerGroundImpassableTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().lowerImpassable = true;
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
