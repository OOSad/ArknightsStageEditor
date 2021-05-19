using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageEditor : MonoBehaviour, IPointerClickHandler
{
    public GameObject stageEditorBlocks;
    public GameObject stageGenerator;

    public int[] tileCoordinates = { 0, 0 };
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
            selectedBlock.GetComponent<StageEditor>().tileCoordinates = this.tileCoordinates;

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
                case "PlayerSpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().playerSpawnTiles.Add(selectedBlock);
                    break;

                default: break;
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
                case "PlayerSpawn(Clone)":
                    stageGenerator.GetComponent<StageGenerator>().playerSpawnTiles.RemoveAt(stageGenerator.GetComponent<StageGenerator>().playerSpawnTiles.IndexOf(this.gameObject));
                    break;

                default: break;
            }

            Destroy(this.gameObject);
        }
    }
}
