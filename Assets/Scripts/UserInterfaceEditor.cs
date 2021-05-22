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
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeNormal = true;
                    break;
                }

            case ("Ranged Normal"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedNormal = true;
                    break;
                }

            case ("Bottomless Pit"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().bottomlessPit = true;
                    break;
                }

            case ("Player Spawn"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().playerSpawn = true;
                    break;
                }

            case ("Enemy Spawn"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().enemySpawn = true;
                    break;
                }

            case ("Drone Spawn"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().enemyDroneSpawn = true;
                    break;
                }

            case ("Melee Restricted"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeRestricted = true;
                    break;
                }

            case ("Ranged Restricted"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedRestricted = true;
                    break;
                }

            case ("Melee Impassable"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeImpassable = true;
                    break;
                }

            case ("Ranged Camouflage"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedCamouflage = true;
                    break;
                }

            case ("Ranged Def Up"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedDefUp = true;
                    break;
                }

            case ("Melee Def Up"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().meleeDefUp = true;
                    break;
                }

            case ("Ranged Regen"):
                {
                    GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>().rangedRegen = true;
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
