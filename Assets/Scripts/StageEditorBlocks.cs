using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEditorBlocks : MonoBehaviour
{
    public GameObject lowerGroundTile;
    public GameObject rangedNormalTile;
    public GameObject playerSpawnTile;
    public GameObject enemySpawnTile;
    public GameObject enemyDroneSpawnTile;
    public GameObject bottomlessPitTile;
    public GameObject lowerGroundRestrictedTile;
    public GameObject higherGroundRestrictedTile;
    public GameObject lowerGroundImpassableTile;
    public GameObject rangedCamouflageTile;


    public GameObject currentlySelectedBlock;

    public bool lowerGround;
    public bool rangedNormal;
    public bool playerSpawn;
    public bool enemySpawn;
    public bool enemyDroneSpawn;
    public bool bottomlessPit;
    public bool lowerRestricted;
    public bool higherRestricted;
    public bool lowerImpassable;
    public bool rangedCamouflage;

    private void Update()
    {
        if (lowerGround)
        {
            currentlySelectedBlock = lowerGroundTile;
            lowerGround = false;
        }

        if (rangedNormal)
        {
            currentlySelectedBlock = rangedNormalTile;
            rangedNormal = false;
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

        if (enemyDroneSpawn)
        {
            currentlySelectedBlock = enemyDroneSpawnTile;
            enemyDroneSpawn = false;
        }

        if (bottomlessPit)
        {
            currentlySelectedBlock = bottomlessPitTile;
            bottomlessPit = false;
        }

        if (lowerRestricted)
        {
            currentlySelectedBlock = lowerGroundRestrictedTile;
            lowerRestricted = false;
        }

        if (higherRestricted)
        {
            currentlySelectedBlock = higherGroundRestrictedTile;
            higherRestricted = false;
        }

        if (lowerImpassable)
        {
            currentlySelectedBlock = lowerGroundImpassableTile;
            lowerImpassable = false;
        }

        if (rangedCamouflage)
        {
            currentlySelectedBlock = rangedCamouflageTile;
            rangedCamouflage = false;
        }
    }
}
