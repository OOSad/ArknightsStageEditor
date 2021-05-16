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
    public GameObject lowerGroundRestricted;
    public GameObject higherGroundRestricted;
    public GameObject lowerGroundImpassable;

    public GameObject currentlySelectedBlock;

    public bool lowerGround;
    public bool higherGround;
    public bool playerSpawn;
    public bool enemySpawn;
    public bool bottomlessPit;
    public bool lowerRestricted;
    public bool higherRestricted;
    public bool lowerImpassable;

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

        if (lowerRestricted)
        {
            currentlySelectedBlock = lowerGroundRestricted;
            lowerRestricted = false;
        }

        if (higherRestricted)
        {
            currentlySelectedBlock = higherGroundRestricted;
            higherRestricted = false;
        }

        if (lowerImpassable)
        {
            currentlySelectedBlock = lowerGroundImpassable;
            lowerImpassable = false;
        }
    }
}
