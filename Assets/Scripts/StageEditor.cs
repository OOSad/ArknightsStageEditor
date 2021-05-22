using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageEditor : MonoBehaviour, IPointerClickHandler
{
    public GameObject stageEditorBlocks;
    public GameObject stageGenerator;

    public string thisTilesName = "";

    private void Start()
    {
        stageEditorBlocks = GameObject.FindGameObjectWithTag("StageEditorBlocks");
        stageGenerator = GameObject.FindGameObjectWithTag("StageGenerator");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject selectedBlock = Instantiate(stageEditorBlocks.GetComponent<StageEditorBlocks>().currentlySelectedBlock);
            selectedBlock.transform.position = new Vector3 (this.transform.position.x, selectedBlock.transform.position.y, this.transform.position.z);

            switch (selectedBlock.name)
            {
                case "MeleeNormal(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().meleeNormalTiles.Add(selectedBlock);
                    break;
                case "RangedNormal(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedNormalTiles.Add(selectedBlock);
                    break;
                case "BottomlessPit(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().bottomlessPitTiles.Add(selectedBlock);
                    break;
                case "EnemySpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().enemySpawnTiles.Add(selectedBlock);
                    break;
                case "EnemyDroneSpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().enemyDroneSpawnTiles.Add(selectedBlock);
                    break;
                case "PlayerSpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().playerSpawnTiles.Add(selectedBlock);
                    break;
                case "MeleeRestricted(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().meleeRestrictedTiles.Add(selectedBlock);
                    break;
                case "RangedRestricted(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedRestrictedTiles.Add(selectedBlock);
                    break;
                case "MeleeImpassable(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().meleeImpassableTiles.Add(selectedBlock);
                    break;
                case "RangedCamouflage(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedCamouflageTiles.Add(selectedBlock);
                    break;
                case "RangedDefUp(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedDefUpTiles.Add(selectedBlock);
                    break;

                default:
                    Debug.Log("Did not find list to add block to! Please check StageEditor script.");
                    break;
            }

            thisTilesName = this.name;

            switch (thisTilesName)
            {
                case "MeleeNormal(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().meleeNormalTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().meleeNormalTiles.IndexOf(this.gameObject));
                    break;
                case "RangedNormal(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedNormalTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().rangedNormalTiles.IndexOf(this.gameObject));
                    break;
                case "BottomlessPit(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().bottomlessPitTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().bottomlessPitTiles.IndexOf(this.gameObject));
                    break;
                case "EnemySpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().enemySpawnTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().enemySpawnTiles.IndexOf(this.gameObject));
                    break;
                case "EnemyDroneSpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().enemyDroneSpawnTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().enemyDroneSpawnTiles.IndexOf(this.gameObject));
                    break;
                case "PlayerSpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().playerSpawnTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().playerSpawnTiles.IndexOf(this.gameObject));
                    break;
                case "MeleeRestricted(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().meleeRestrictedTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().meleeRestrictedTiles.IndexOf(this.gameObject));
                    break;
                case "RangedRestricted(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedRestrictedTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().rangedRestrictedTiles.IndexOf(this.gameObject));
                    break;
                case "MeleeImpassable(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().meleeImpassableTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().meleeImpassableTiles.IndexOf(this.gameObject));
                    break;
                case "RangedCamouflage(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedCamouflageTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().rangedCamouflageTiles.IndexOf(this.gameObject));
                    break;
                case "RangedDefUp(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().rangedDefUpTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().rangedDefUpTiles.IndexOf(this.gameObject));
                    break;

                default:
                    Debug.Log("Did not find list to remove block from! Please check StageEditor script.");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
