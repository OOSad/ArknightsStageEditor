using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEditorBlocks : MonoBehaviour
{
    public GameObject meleeNormalTile;
    public GameObject rangedNormalTile;
    public GameObject playerSpawnTile;
    public GameObject enemySpawnTile;
    public GameObject enemyDroneSpawnTile;
    public GameObject bottomlessPitTile;
    public GameObject meleeRestrictedTile;
    public GameObject rangedRestrictedTile;
    public GameObject meleeImpassableTile;
    public GameObject rangedCamouflageTile;
    public GameObject rangedDefUpTile;
    public GameObject meleeDefUpTile;
    public GameObject rangedRegenTile;
    public GameObject meleeRegenTile;


    public GameObject currentlySelectedBlock;

    public bool meleeNormal;
    public bool rangedNormal;
    public bool playerSpawn;
    public bool enemySpawn;
    public bool enemyDroneSpawn;
    public bool bottomlessPit;
    public bool meleeRestricted;
    public bool rangedRestricted;
    public bool meleeImpassable;
    public bool rangedCamouflage;
    public bool rangedDefUp;
    public bool meleeDefUp;
    public bool rangedRegen;
    public bool meleeRegen;

    private void Update()
    {
        if (meleeNormal)
        {
            currentlySelectedBlock = meleeNormalTile;
            meleeNormal = false;
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

        if (meleeRestricted)
        {
            currentlySelectedBlock = meleeRestrictedTile;
            meleeRestricted = false;
        }

        if (rangedRestricted)
        {
            currentlySelectedBlock = rangedRestrictedTile;
            rangedRestricted = false;
        }

        if (meleeImpassable)
        {
            currentlySelectedBlock = meleeImpassableTile;
            meleeImpassable = false;
        }

        if (rangedCamouflage)
        {
            currentlySelectedBlock = rangedCamouflageTile;
            rangedCamouflage = false;
        }

        if (rangedDefUp)
        {
            currentlySelectedBlock = rangedDefUpTile;
            rangedDefUp = false;
        }

        if (meleeDefUp)
        {
            currentlySelectedBlock = meleeDefUpTile;
            meleeDefUp = false;
        }

        if (rangedRegen)
        {
            currentlySelectedBlock = rangedRegenTile;
            rangedRegen = false;
        }

        if (meleeRegen)
        {
            currentlySelectedBlock = meleeRegenTile;
            meleeRegen = false;
        }
    }
}
