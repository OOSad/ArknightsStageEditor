using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    public GameObject rangedNormal;
    public GameObject meleeNormal;
    public GameObject edgeGround;
    public GameObject enemySpawn;
    public GameObject playerSpawn;
    public GameObject bottomlessPit;
    public GameObject meleeRestricted;
    public GameObject rangedRestricted;
    public GameObject meleeImpassable;
    public GameObject enemyDroneSpawn;
    public GameObject rangedCamouflage;

    public List<GameObject> meleeNormalTiles = new List<GameObject>();
    public List<GameObject> rangedNormalTiles = new List<GameObject>();
    public List<GameObject> edgeOfStageTiles = new List<GameObject>();
    public List<GameObject> bottomlessPitTiles = new List<GameObject>();
    public List<GameObject> enemySpawnTiles = new List<GameObject>();
    public List<GameObject> playerSpawnTiles = new List<GameObject>();
    public List<GameObject> meleeRestrictedTiles = new List<GameObject>();
    public List<GameObject> rangedRestrictedTiles = new List<GameObject>();
    public List<GameObject> meleeImpassableTiles = new List<GameObject>();
    public List<GameObject> enemyDroneSpawnTiles = new List<GameObject>();
    public List<GameObject> rangedCamouflageTiles = new List<GameObject>();

    public int stageWidthEditor;
    public int stageHeightEditor;
    public int numberOfRangedNormalTilesEditor;
    public int numberOfBottomlessPitsEditor;
    public int numberOfEnemySpawnsEditor;
    public int numberOfPlayerSpawnsEditor;
    public int numberOfMeleeRestrictedEditor;
    public int numberOfRangedRestrictedEditor;
    public int numberOfMeleeImpassableEditor;
    public int numberOfEnemyDroneSpawnsEditor;
    public int numberOfRangedCamouflageTilesEditor;

    private int stageWidth = 10;
    private int stageHeight = 5;
    private int numberOfRangedNormalTiles = 15;
    private int numberOfBottomlessPits = 2;
    private int numberOfEnemySpawns = 1;
    private int numberOfPlayerSpawns = 1;
    private int numberOfMeleeRestrictedTiles = 1;
    private int numberOfRangedRestrictedTiles = 1;
    private int numberOfMeleeImpassableTiles = 1;
    private int numberOfEnemyDroneSpawns = 1;
    private int numberOfRangedCamouflageTiles = 1;

    public bool playerSpawnOnOutside = false;
    public bool enemySpawnOnOutside = false;
    public bool regenerateStage = false;

    private void Start()
    {
        RegenerateStage();
        UpdateEditorValues();
    }


    private void Update()
    {
        if (numberOfRangedNormalTilesEditor < 0)
        {
            numberOfRangedNormalTilesEditor = 0;
        }

        if (stageWidthEditor > 22)
        {
            stageWidthEditor = 22;
        }

        if (stageWidthEditor < 7)
        {
            stageWidthEditor = 7;
        }

        if (stageHeightEditor > 16)
        {
            stageHeightEditor = 16;
        }

        if (stageHeightEditor < 4)
        {
            stageHeightEditor = 4;
        }

        if (stageWidth != stageWidthEditor ||
            stageHeight != stageHeightEditor ||
            numberOfRangedNormalTiles != numberOfRangedNormalTilesEditor ||
            numberOfBottomlessPits != numberOfBottomlessPitsEditor ||
            numberOfEnemySpawns != numberOfEnemySpawnsEditor ||
            numberOfEnemyDroneSpawns != numberOfEnemyDroneSpawnsEditor ||
            numberOfPlayerSpawns != numberOfPlayerSpawnsEditor ||
            numberOfMeleeRestrictedTiles != numberOfMeleeRestrictedEditor ||
            numberOfRangedRestrictedTiles != numberOfRangedRestrictedEditor ||
            numberOfMeleeImpassableTiles != numberOfMeleeImpassableEditor ||
            numberOfRangedCamouflageTiles != numberOfRangedCamouflageTilesEditor ||
            regenerateStage == true)
        {
            DestroyStage();

            UpdatePrivateStageValues();

            CreateLowerGround();
            CreateEdgeTiles();

            PlaceThisTileAroundRandomly(rangedNormal, numberOfRangedNormalTiles, rangedNormalTiles);

            PlaceThisSpawnAroundRandomly(playerSpawn, numberOfPlayerSpawns, playerSpawnTiles, playerSpawnOnOutside);
            PlaceThisSpawnAroundRandomly(enemySpawn, numberOfEnemySpawns, enemySpawnTiles, enemySpawnOnOutside);
            PlaceThisSpawnAroundRandomly(enemyDroneSpawn, numberOfEnemyDroneSpawns, enemyDroneSpawnTiles, enemySpawnOnOutside);

            PlaceThisTileAroundRandomly(bottomlessPit, numberOfBottomlessPits, bottomlessPitTiles);
            PlaceThisTileAroundRandomly(meleeRestricted, numberOfMeleeRestrictedTiles, meleeRestrictedTiles);
            PlaceThisTileAroundRandomly(rangedRestricted, numberOfRangedRestrictedTiles, rangedRestrictedTiles);
            PlaceThisTileAroundRandomly(meleeImpassable, numberOfMeleeImpassableTiles, meleeImpassableTiles);
            PlaceThisTileAroundRandomly(rangedCamouflage, numberOfRangedCamouflageTiles, rangedCamouflageTiles);
        }
    }

    private void CreateLowerGround()
    {
        for (int i = 0; i < stageWidth * stageHeight; i++)
        {
            meleeNormalTiles.Add(Instantiate(meleeNormal));
        }

        int incrementedWidth = 0;
        int incrementedHeight = 0;

        for (int i = 0; i < meleeNormalTiles.Count; i++)
        {
            meleeNormalTiles[i].transform.Translate(incrementedWidth, 0, incrementedHeight);
            incrementedWidth++;

            meleeNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = incrementedWidth;
            meleeNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = incrementedHeight + 1;

            if (incrementedWidth >= stageWidth)
            {
                incrementedWidth = 0;
                incrementedHeight++;
            }
        }
    }

    private void CreateEdgeTiles()
    {
        int totalNumberOfEdgeTiles = (stageWidth * 2) + (stageHeight * 2);

        for (int i = 0; i < totalNumberOfEdgeTiles; i++)
        {
            edgeOfStageTiles.Add(Instantiate(edgeGround));
        }


        int indexIncrement = 0;

        for (int i = 0; i < meleeNormalTiles.Count; i++)
        {
            if (meleeNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[1] == stageHeight)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(meleeNormalTiles[i].transform.position.x, meleeNormalTiles[i].transform.position.y, meleeNormalTiles[i].transform.position.z + 1);
                indexIncrement++;
            }

            if (meleeNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[0] == stageWidth)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(meleeNormalTiles[i].transform.position.x + 1, meleeNormalTiles[i].transform.position.y, meleeNormalTiles[i].transform.position.z);
                indexIncrement++;
            }

            if (meleeNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[1] == 1)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(meleeNormalTiles[i].transform.position.x, meleeNormalTiles[i].transform.position.y, meleeNormalTiles[i].transform.position.z - 1);
                indexIncrement++;
            }

            if (meleeNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[0] == 1)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(meleeNormalTiles[i].transform.position.x - 1, meleeNormalTiles[i].transform.position.y, meleeNormalTiles[i].transform.position.z);
                indexIncrement++;
            }
        }
    }

    private void PlaceThisTileAroundRandomly(GameObject tile, int numberOfTilesYouWantToPlace, List<GameObject> listToAddTilesInto)
    {
        for (int i = 0; i < numberOfTilesYouWantToPlace; i++)
        {
            listToAddTilesInto.Add(Instantiate(tile));

            GameObject randomMeleeNormalTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            listToAddTilesInto[i].transform.position = new Vector3(randomMeleeNormalTile.transform.position.x, tile.transform.position.y, randomMeleeNormalTile.transform.position.z);
            listToAddTilesInto[i].GetComponent<StageEditor>().tileCoordinates[0] = randomMeleeNormalTile.GetComponent<StageEditor>().tileCoordinates[0];
            listToAddTilesInto[i].GetComponent<StageEditor>().tileCoordinates[1] = randomMeleeNormalTile.GetComponent<StageEditor>().tileCoordinates[1];

            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(randomMeleeNormalTile));
            Destroy(randomMeleeNormalTile);
        }
    }

    private void PlaceThisSpawnAroundRandomly(GameObject spawnTile, int numberOfSpawnsYouWantToPlace, List<GameObject> listToAddSpawnsInto, bool placeSpawnsOnTheEdge)
    {
        for (int i = 0; i < numberOfSpawnsYouWantToPlace; i++)
        {
            listToAddSpawnsInto.Add(Instantiate(spawnTile));
        }

        for (int i = 0; i < listToAddSpawnsInto.Count; i++)
        {
            if (placeSpawnsOnTheEdge)
            {
                GameObject selectedEdgeTile = edgeOfStageTiles[Random.Range(0, edgeOfStageTiles.Count)];

                listToAddSpawnsInto[i].transform.position = new Vector3(selectedEdgeTile.transform.position.x, spawnTile.transform.position.y, selectedEdgeTile.transform.position.z);

                listToAddSpawnsInto[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[0];
                listToAddSpawnsInto[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[1];

                edgeOfStageTiles.RemoveAt(edgeOfStageTiles.IndexOf(selectedEdgeTile));
            }

            else
            {
                GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

                listToAddSpawnsInto[i].transform.position = new Vector3(selectedTile.transform.position.x, spawnTile.transform.position.y, selectedTile.transform.position.z);

                listToAddSpawnsInto[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
                listToAddSpawnsInto[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

                meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

                Destroy(selectedTile);
            }
        }
    }

    private void DestroyStage()
    {
        List<List<GameObject>> tileListIndex = new List<List<GameObject>>() { meleeNormalTiles, rangedNormalTiles, edgeOfStageTiles, bottomlessPitTiles, enemySpawnTiles, enemyDroneSpawnTiles, playerSpawnTiles, meleeRestrictedTiles, rangedRestrictedTiles, meleeImpassableTiles, rangedCamouflageTiles };

        for (int i = 0; i < tileListIndex.Count; i++)
        {
            foreach (GameObject tileInStage in tileListIndex[i])
            {
                Destroy(tileInStage);
            }
        }

        foreach (List<GameObject> listOfTiles in tileListIndex)
        {
            listOfTiles.Clear();
        }
    }

    private void UpdateEditorValues()
    {
        stageWidthEditor = stageWidth;
        stageHeightEditor = stageHeight;
        numberOfRangedNormalTilesEditor = numberOfRangedNormalTiles;
        numberOfBottomlessPitsEditor = numberOfBottomlessPits;
        numberOfEnemySpawnsEditor = numberOfEnemySpawns;
        numberOfEnemyDroneSpawnsEditor = numberOfEnemyDroneSpawns;
        numberOfPlayerSpawnsEditor = numberOfPlayerSpawns;
        numberOfMeleeRestrictedEditor = numberOfMeleeRestrictedTiles;
        numberOfRangedRestrictedEditor = numberOfRangedRestrictedTiles;
        numberOfMeleeImpassableEditor = numberOfMeleeImpassableTiles;
        numberOfRangedCamouflageTilesEditor = numberOfRangedCamouflageTiles;
    }

    private void UpdatePrivateStageValues()
    {
        stageWidth = stageWidthEditor;
        stageHeight = stageHeightEditor;
        numberOfRangedNormalTiles = numberOfRangedNormalTilesEditor;
        numberOfBottomlessPits = numberOfBottomlessPitsEditor;
        numberOfEnemySpawns = numberOfEnemySpawnsEditor;
        numberOfEnemyDroneSpawns = numberOfEnemyDroneSpawnsEditor;
        numberOfPlayerSpawns = numberOfPlayerSpawnsEditor;
        numberOfMeleeRestrictedTiles = numberOfMeleeRestrictedEditor;
        numberOfRangedRestrictedTiles = numberOfRangedRestrictedEditor;
        numberOfMeleeImpassableTiles = numberOfMeleeImpassableEditor;
        numberOfRangedCamouflageTiles = numberOfRangedCamouflageTilesEditor;

        regenerateStage = false;
    }

    public void RegenerateStage()
    {
        regenerateStage = true;
    }
}
