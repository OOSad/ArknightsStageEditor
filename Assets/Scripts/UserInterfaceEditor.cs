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

            case ("Ranged Tile"):
                {
                    QueueUpHigherGroundTile();
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

            default: break;
        }
    }

    public void QueueUpLowerGroundTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().lowerGround = true;
    }

    public void QueueUpHigherGroundTile()
    {
        GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().higherGround = true;
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



    public void SwitchToGeneratorMode()
    {
        generatorModeUICanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
