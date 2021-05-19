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
    public GameObject lowerGroundRestricted;
    public GameObject higherGroundRestricted;
    public GameObject lowerGroundImpassable;
    public GameObject enemyDroneSpawn;
    public GameObject rangedCamouflage;

    public List<GameObject> rangedNormalTiles = new List<GameObject>();
    public List<GameObject> meleeNormalTiles = new List<GameObject>();
    public List<GameObject> edgeOfStageTiles = new List<GameObject>();
    public List<GameObject> bottomlessPitTiles = new List<GameObject>();
    public List<GameObject> enemySpawnTiles = new List<GameObject>();
    public List<GameObject> playerSpawnTiles = new List<GameObject>();
    public List<GameObject> lowerGroundRestrictedTiles = new List<GameObject>();
    public List<GameObject> higherGroundRestrictedTiles = new List<GameObject>();
    public List<GameObject> lowerGroundImpassableTiles = new List<GameObject>();
    public List<GameObject> enemyDroneSpawnTiles = new List<GameObject>();
    public List<GameObject> rangedCamouflageTiles = new List<GameObject>();


    public int stageWidthEditor;
    public int stageHeightEditor;
    public int numberOfRangedNormalTilesEditor;
    public int numberOfBottomlessPitsEditor;
    public int numberOfEnemySpawnsEditor;
    public int numberOfPlayerSpawnsEditor;
    public int numberOfLowerGroundRestrictedEditor;
    public int numberOfHigherGroundRestrictedEditor;
    public int numberOfLowerGroundImpassableEditor;
    public int numberOfEnemyDroneSpawnsEditor;
    public int numberOfRangedCamouflageTilesEditor;

    private int stageWidth = 10;
    private int stageHeight = 5;
    private int numberOfRangedNormalTiles = 15;
    private int numberOfBottomlessPits = 2;
    private int numberOfEnemySpawns = 1;
    private int numberOfPlayerSpawns = 1;
    private int numberOfLowerGroundRestricted = 1;
    private int numberOfHigherGroundRestricted = 1;
    private int numberOfLowerGroundImpassable = 1;
    private int numberOfEnemyDroneSpawns = 1;
    private int numberOfRangedCamouflageTiles = 1;

    public bool playerSpawnOnOutside = false;
    public bool enemySpawnOnOutside = false;
    public bool regenerateStage = false;

    private void Start()
    {
        DestroyStage();

        CreateLowerGround();
        CreateEdgeTiles();

        PlaceRangedNormalTilesRandomly();

        PlacePlayerSpawnsRandomly();
        PlaceEnemySpawnsRandomly();
        PlaceEnemyDroneSpawnsRandomly();

        PlaceBottomlessPitsRandomly();

        PlaceLowerGroundRestrictedRandomly();
        PlaceHigherGroundRestrictedRandomly();

        PlaceLowerGroundImpassableRandomly();

        PlaceRangedCamouflageTilesRandomly();

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
            numberOfLowerGroundRestricted != numberOfLowerGroundRestrictedEditor ||
            numberOfHigherGroundRestricted != numberOfHigherGroundRestrictedEditor ||
            numberOfLowerGroundImpassable != numberOfLowerGroundImpassableEditor ||
            numberOfRangedCamouflageTiles != numberOfRangedCamouflageTilesEditor ||
            regenerateStage == true)
        {
            DestroyStage();

            UpdatePrivateStageValues();

            CreateLowerGround();
            CreateEdgeTiles();

            PlaceRangedNormalTilesRandomly();

            PlacePlayerSpawnsRandomly();
            PlaceEnemySpawnsRandomly();
            PlaceEnemyDroneSpawnsRandomly();

            PlaceBottomlessPitsRandomly();

            PlaceLowerGroundRestrictedRandomly();
            PlaceHigherGroundRestrictedRandomly();

            PlaceLowerGroundImpassableRandomly();

            PlaceRangedCamouflageTilesRandomly();
        }
    }

    

    private void CreateLowerGround()
    {
        for (int i = 0; i < stageWidth * stageHeight; i++)
        {
            meleeNormalTiles.Add(Instantiate(meleeNormal));
        }

        // Position melee tiles on stage.
        // Give all of the melee tiles an x and y coordinate.

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

        // Find the edges of the stage, and place edge blocks there.

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

    private void PlaceRangedNormalTilesRandomly()
    {
        for (int i = 0; i < numberOfRangedNormalTiles; i++)
        {
            rangedNormalTiles.Add(Instantiate(rangedNormal));

            GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            rangedNormalTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1, selectedTile.transform.position.z);

            rangedNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            rangedNormalTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];


            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));
            Destroy(selectedTile);
        }
    }

    private void PlaceBottomlessPitsRandomly()
    {
        for (int i = 0; i < numberOfBottomlessPits; i++)
        {
            bottomlessPitTiles.Add(Instantiate(bottomlessPit));

        }

        for (int i = 0; i < bottomlessPitTiles.Count; i++)
        {
            GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            bottomlessPitTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 0.5f, selectedTile.transform.position.z);

            bottomlessPitTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            bottomlessPitTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

            Destroy(meleeNormalTiles[meleeNormalTiles.IndexOf(selectedTile)]);
            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));
        }
    }

    private void PlacePlayerSpawnsRandomly()
    {
        for (int i = 0; i < numberOfPlayerSpawns; i++)
        {
            playerSpawnTiles.Add(Instantiate(playerSpawn));
        }

        for (int i = 0; i < playerSpawnTiles.Count; i++)
        {
            if (playerSpawnOnOutside)
            {
                GameObject selectedEdgeTile = edgeOfStageTiles[Random.Range(0, edgeOfStageTiles.Count)];

                playerSpawnTiles[i].transform.position = new Vector3(selectedEdgeTile.transform.position.x, 1.5f, selectedEdgeTile.transform.position.z);

                playerSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[0];
                playerSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[1];

                edgeOfStageTiles.RemoveAt(edgeOfStageTiles.IndexOf(selectedEdgeTile));
            }

            else
            {
                GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

                playerSpawnTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1.5f, selectedTile.transform.position.z);

                playerSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
                playerSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

                meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

                Destroy(selectedTile);
            }
        }
    }

    private void PlaceEnemySpawnsRandomly()
    {
        for (int i = 0; i < numberOfEnemySpawns; i++)
        {
            enemySpawnTiles.Add(Instantiate(enemySpawn));
        }

        for (int i = 0; i < enemySpawnTiles.Count; i++)
        {
            if (enemySpawnOnOutside)
            {
                GameObject selectedEdgeTile = edgeOfStageTiles[Random.Range(0, edgeOfStageTiles.Count)];

                enemySpawnTiles[i].transform.position = new Vector3(selectedEdgeTile.transform.position.x, 1.5f, selectedEdgeTile.transform.position.z);

                enemySpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[0];
                enemySpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[1];

                edgeOfStageTiles.RemoveAt(edgeOfStageTiles.IndexOf(selectedEdgeTile));
            }

            else
            {
                GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

                enemySpawnTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1.5f, selectedTile.transform.position.z);

                enemySpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
                enemySpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

                meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

                Destroy(selectedTile);
            }
        }
    }

    public void PlaceEnemyDroneSpawnsRandomly()
    {
        for (int i = 0; i < numberOfEnemyDroneSpawns; i++)
        {
            enemyDroneSpawnTiles.Add(Instantiate(enemyDroneSpawn));
        }

        for (int i = 0; i < enemyDroneSpawnTiles.Count; i++)
        {
            if (enemySpawnOnOutside)
            {
                GameObject selectedEdgeTile = edgeOfStageTiles[Random.Range(0, edgeOfStageTiles.Count)];

                enemyDroneSpawnTiles[i].transform.position = new Vector3(selectedEdgeTile.transform.position.x, 1f, selectedEdgeTile.transform.position.z);

                enemyDroneSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[0];
                enemyDroneSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedEdgeTile.GetComponent<StageEditor>().tileCoordinates[1];

                edgeOfStageTiles.RemoveAt(edgeOfStageTiles.IndexOf(selectedEdgeTile));
            }

            else
            {
                GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

                enemyDroneSpawnTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1f, selectedTile.transform.position.z);

                enemyDroneSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
                enemyDroneSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

                meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

                Destroy(selectedTile);
            }
        }
    }

    public void PlaceLowerGroundRestrictedRandomly()
    {
        for (int i = 0; i < numberOfLowerGroundRestricted; i++)
        {
            lowerGroundRestrictedTiles.Add(Instantiate(lowerGroundRestricted));

            GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            lowerGroundRestrictedTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 0.5f, selectedTile.transform.position.z);

            lowerGroundRestrictedTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            lowerGroundRestrictedTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

            Destroy(selectedTile);
        }
    }

    public void PlaceHigherGroundRestrictedRandomly()
    {
        for (int i = 0; i < numberOfHigherGroundRestricted; i++)
        {
            higherGroundRestrictedTiles.Add(Instantiate(higherGroundRestricted));

            GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            higherGroundRestrictedTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1f, selectedTile.transform.position.z);

            higherGroundRestrictedTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            higherGroundRestrictedTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

            Destroy(selectedTile);
        }
    }

    public void PlaceLowerGroundImpassableRandomly()
    {
        for (int i = 0; i < numberOfLowerGroundImpassable; i++)
        {
            lowerGroundImpassableTiles.Add(Instantiate(lowerGroundImpassable));

            GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            lowerGroundImpassableTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 0.5f, selectedTile.transform.position.z);

            lowerGroundImpassableTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            lowerGroundImpassableTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));

            Destroy(selectedTile);
        }
    }

    private void PlaceRangedCamouflageTilesRandomly()
    {
        for (int i = 0; i < numberOfRangedCamouflageTiles; i++)
        {
            rangedCamouflageTiles.Add(Instantiate(rangedCamouflage));

            GameObject selectedTile = meleeNormalTiles[Random.Range(0, meleeNormalTiles.Count)];

            rangedCamouflageTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1, selectedTile.transform.position.z);

            rangedCamouflageTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            rangedCamouflageTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];


            meleeNormalTiles.RemoveAt(meleeNormalTiles.IndexOf(selectedTile));
            Destroy(selectedTile);
        }
    }

    private void DestroyStage()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("MeleeNormal").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("MeleeNormal")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("RangedNormal").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("RangedNormal")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("EdgeGround").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("EdgeGround")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("BottomlessPit").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("BottomlessPit")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("EnemySpawn").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("EnemySpawn")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("EnemyDroneSpawn").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("EnemyDroneSpawn")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("PlayerSpawn").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("PlayerSpawn")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("LowerGroundRestricted").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("LowerGroundRestricted")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("HigherGroundRestricted").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("HigherGroundRestricted")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("LowerGroundImpassable").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("LowerGroundImpassable")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("RangedCamouflage").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("RangedCamouflage")[i]);
        }

        meleeNormalTiles.Clear();
        rangedNormalTiles.Clear();
        edgeOfStageTiles.Clear();
        bottomlessPitTiles.Clear();
        enemySpawnTiles.Clear();
        enemyDroneSpawnTiles.Clear();
        playerSpawnTiles.Clear();
        lowerGroundRestrictedTiles.Clear();
        higherGroundRestrictedTiles.Clear();
        lowerGroundImpassableTiles.Clear();
        rangedCamouflageTiles.Clear();
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
        numberOfLowerGroundRestrictedEditor = numberOfLowerGroundRestricted;
        numberOfHigherGroundRestrictedEditor = numberOfHigherGroundRestricted;
        numberOfLowerGroundImpassableEditor = numberOfLowerGroundImpassable;
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
        numberOfLowerGroundRestricted = numberOfLowerGroundRestrictedEditor;
        numberOfHigherGroundRestricted = numberOfHigherGroundRestrictedEditor;
        numberOfLowerGroundImpassable = numberOfLowerGroundImpassableEditor;
        numberOfRangedCamouflageTiles = numberOfRangedCamouflageTilesEditor;

        regenerateStage = false;
    }

    public void RegenerateStage()
    {
        regenerateStage = true;
    }
}
