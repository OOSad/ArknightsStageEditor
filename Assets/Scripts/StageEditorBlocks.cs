using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEditorBlocks : MonoBehaviour
{
    public GameObject lowerGroundTile;
    public GameObject higherGroundTile;
    public GameObject playerSpawnTile;
    public GameObject enemySpawnTile;
    public GameObject bottomlessPitTile;

    public GameObject currentlySelectedBlock;

    public bool lowerGround;
    public bool higherGround;
    public bool playerSpawn;
    public bool enemySpawn;
    public bool bottomlessPit;

    private void Update()
    {
        if (lowerGround)
        {
            currentlySelectedBlock = lowerGroundTile;
            lowerGround = false;
        }

        if (higherGround)
        {
            currentlySelectedBlock = higherGroundTile;
            higherGround = false;
        }

        if (playerSpawn)
        {
            currentlySelectedBlock = playerSpawnTile;
            playerSpawn = false;
        }

        if (enemySpawn)
        {
            currentlySelectedBlock = enemySpawnTile;
            enemySpawn = false;
        }

        if (bottomlessPit)
        {
            currentlySelectedBlock = bottomlessPitTile;
            bottomlessPit = false;
        }
    }
}
