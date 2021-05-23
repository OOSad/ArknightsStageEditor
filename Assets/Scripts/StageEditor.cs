﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageEditor : MonoBehaviour, IPointerClickHandler
{
    private StageEditorBlocks stageEditorBlocks;
    private StageGenerator stageGenerator;

    public string thisTilesName = "";

    private void Start()
    {
        stageEditorBlocks = GameObject.FindGameObjectWithTag("StageEditorBlocks").GetComponent<StageEditorBlocks>();
        stageGenerator = GameObject.FindGameObjectWithTag("StageGenerator").GetComponent<StageGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject selectedBlock = Instantiate(stageEditorBlocks.currentlySelectedBlock);
            selectedBlock.transform.position = new Vector3 (this.transform.position.x, selectedBlock.transform.position.y, this.transform.position.z);

            switch (selectedBlock.name)
            {
                case "MeleeNormal(Clone)":
                    stageGenerator.meleeNormalTiles.Add(selectedBlock);
                    break;
                case "RangedNormal(Clone)":
                    stageGenerator.rangedNormalTiles.Add(selectedBlock);
                    break;
                case "BottomlessPit(Clone)":
                    stageGenerator.bottomlessPitTiles.Add(selectedBlock);
                    break;
                case "EnemySpawn(Clone)":
                    stageGenerator.enemySpawnTiles.Add(selectedBlock);
                    break;
                case "EnemyDroneSpawn(Clone)":
                    stageGenerator.enemyDroneSpawnTiles.Add(selectedBlock);
                    break;
                case "PlayerSpawn(Clone)":
                    stageGenerator.playerSpawnTiles.Add(selectedBlock);
                    break;
                case "MeleeRestricted(Clone)":
                    stageGenerator.meleeRestrictedTiles.Add(selectedBlock);
                    break;
                case "RangedRestricted(Clone)":
                    stageGenerator.rangedRestrictedTiles.Add(selectedBlock);
                    break;
                case "MeleeImpassable(Clone)":
                    stageGenerator.meleeImpassableTiles.Add(selectedBlock);
                    break;
                case "RangedCamouflage(Clone)":
                    stageGenerator.rangedCamouflageTiles.Add(selectedBlock);
                    break;
                case "RangedDefUp(Clone)":
                    stageGenerator.rangedDefUpTiles.Add(selectedBlock);
                    break;
                case "MeleeDefUp(Clone)":
                    stageGenerator.meleeDefUpTiles.Add(selectedBlock);
                    break;
                case "RangedRegen(Clone)":
                    stageGenerator.rangedRegenTiles.Add(selectedBlock);
                    break;
                case "MeleeRegen(Clone)":
                    stageGenerator.meleeRegenTiles.Add(selectedBlock);
                    break;

                default:
                    Debug.Log("Did not find list to add block to! Please check StageEditor script.");
                    break;
            }

            thisTilesName = this.name;

            switch (thisTilesName)
            {
                case "MeleeNormal(Clone)":
                    stageGenerator.meleeNormalTiles.RemoveAt(stageGenerator.meleeNormalTiles.IndexOf(this.gameObject));
                    break;
                case "RangedNormal(Clone)":
                    stageGenerator.rangedNormalTiles.RemoveAt(stageGenerator.rangedNormalTiles.IndexOf(this.gameObject));
                    break;
                case "BottomlessPit(Clone)":
                    stageGenerator.bottomlessPitTiles.RemoveAt(stageGenerator.bottomlessPitTiles.IndexOf(this.gameObject));
                    break;
                case "EnemySpawn(Clone)":
                    stageGenerator.enemySpawnTiles.RemoveAt(stageGenerator.enemySpawnTiles.IndexOf(this.gameObject));
                    break;
                case "EnemyDroneSpawn(Clone)":
                    stageGenerator.enemyDroneSpawnTiles.RemoveAt(stageGenerator.enemyDroneSpawnTiles.IndexOf(this.gameObject));
                    break;
                case "PlayerSpawn(Clone)":
                    stageGenerator.playerSpawnTiles.RemoveAt(stageGenerator.playerSpawnTiles.IndexOf(this.gameObject));
                    break;
                case "MeleeRestricted(Clone)":
                    stageGenerator.meleeRestrictedTiles.RemoveAt(stageGenerator.meleeRestrictedTiles.IndexOf(this.gameObject));
                    break;
                case "RangedRestricted(Clone)":
                    stageGenerator.rangedRestrictedTiles.RemoveAt(stageGenerator.rangedRestrictedTiles.IndexOf(this.gameObject));
                    break;
                case "MeleeImpassable(Clone)":
                    stageGenerator.meleeImpassableTiles.RemoveAt(stageGenerator.meleeImpassableTiles.IndexOf(this.gameObject));
                    break;
                case "RangedCamouflage(Clone)":
                    stageGenerator.rangedCamouflageTiles.RemoveAt(stageGenerator.rangedCamouflageTiles.IndexOf(this.gameObject));
                    break;
                case "RangedDefUp(Clone)":
                    stageGenerator.rangedDefUpTiles.RemoveAt(stageGenerator.rangedDefUpTiles.IndexOf(this.gameObject));
                    break;
                case "MeleeDefUp(Clone)":
                    stageGenerator.meleeDefUpTiles.RemoveAt(stageGenerator.meleeDefUpTiles.IndexOf(this.gameObject));
                    break;
                case "RangedRegen(Clone)":
                    stageGenerator.rangedRegenTiles.RemoveAt(stageGenerator.rangedRegenTiles.IndexOf(this.gameObject));
                    break;
                case "MeleeRegen(Clone)":
                    stageGenerator.meleeRegenTiles.RemoveAt(stageGenerator.meleeRegenTiles.IndexOf(this.gameObject));
                    break;

                default:
                    Debug.Log("Did not find list to remove block from! Please check StageEditor script.");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
