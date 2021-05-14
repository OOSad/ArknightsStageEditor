using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageGenerator : MonoBehaviour
{
    public Keyboard keyboard;
    public GameObject higherGround;
    public GameObject lowerGround;
    public GameObject edgeGround;
    public GameObject enemySpawn;
    public GameObject playerSpawn;
    public GameObject bottomlessPit;

    public List<GameObject> lowerGroundTiles = new List<GameObject>();
    public List<GameObject> edgeOfStageTiles = new List<GameObject>();
    public List<GameObject> higherGroundTiles = new List<GameObject>();
    public List<GameObject> bottomlessPitTiles = new List<GameObject>();
    public List<GameObject> enemySpawnTiles = new List<GameObject>();
    public List<GameObject> playerSpawnTiles = new List<GameObject>();


    public int stageWidthEditor;
    public int stageHeightEditor;
    public int numberOfHigherGroundTilesEditor;
    public int numberOfBottomlessPitsEditor;
    public int numberOfEnemySpawnsEditor;
    public int numberOfPlayerSpawnsEditor;

    private int stageWidth = 10;
    private int stageHeight = 5;
    private int numberOfHigherGroundTiles = 15;
    private int numberOfBottomlessPits = 2;
    private int numberOfEnemySpawns = 1;
    private int numberOfPlayerSpawns = 1;

    public bool playerSpawnOnOutside = false;
    public bool enemySpawnOnOutside = false;
    public bool regenerateStage = false;

    private void Start()
    {
        DestroyStage();

        CreateLowerGround();
        CreateEdgeTiles();

        PlaceHigherGroundTilesRandomly();

        PlacePlayerSpawns();
        PlaceEnemySpawns();

        PlaceBottomlessPitsRandomly();

        UpdateEditorValues();
    }


    private void Update()
    {
        if (numberOfHigherGroundTilesEditor < 0)
        {
            numberOfHigherGroundTilesEditor = 0;
        }

        if (stageWidthEditor > 11)
        {
            stageWidthEditor = 11;
        }

        if (stageWidthEditor < 7)
        {
            stageWidthEditor = 7;
        }

        if (stageHeightEditor > 8)
        {
            stageHeightEditor = 8;
        }

        if (stageHeightEditor < 4)
        {
            stageHeightEditor = 4;
        }

        if (stageWidth != stageWidthEditor ||
            stageHeight != stageHeightEditor ||
            numberOfHigherGroundTiles != numberOfHigherGroundTilesEditor ||
            numberOfBottomlessPits != numberOfBottomlessPitsEditor ||
            numberOfEnemySpawns != numberOfEnemySpawnsEditor ||
            numberOfPlayerSpawns != numberOfPlayerSpawnsEditor ||
            regenerateStage == true)
        {
            DestroyStage();

            UpdatePrivateStageValues();

            CreateLowerGround();
            CreateEdgeTiles();

            PlaceHigherGroundTilesRandomly();

            PlacePlayerSpawns();
            PlaceEnemySpawns();

            PlaceBottomlessPitsRandomly();
        }
    }

    

    private void CreateLowerGround()
    {
        for (int i = 0; i < stageWidth * stageHeight; i++)
        {
            lowerGroundTiles.Add(Instantiate(lowerGround));
        }

        // Position lower ground tiles on stage.
        // Give all of the lower ground tiles an x and y coordinate.

        int incrementedWidth = 0;
        int incrementedHeight = 0;

        for (int i = 0; i < lowerGroundTiles.Count; i++)
        {
            lowerGroundTiles[i].transform.Translate(incrementedWidth, 0, incrementedHeight);
            incrementedWidth++;

            lowerGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = incrementedWidth;
            lowerGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = incrementedHeight + 1;

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

        for (int i = 0; i < lowerGroundTiles.Count; i++)
        {
            if (lowerGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[1] == stageHeight)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(lowerGroundTiles[i].transform.position.x, lowerGroundTiles[i].transform.position.y, lowerGroundTiles[i].transform.position.z + 1);
                indexIncrement++;
            }

            if (lowerGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[0] == stageWidth)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(lowerGroundTiles[i].transform.position.x + 1, lowerGroundTiles[i].transform.position.y, lowerGroundTiles[i].transform.position.z);
                indexIncrement++;
            }

            if (lowerGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[1] == 1)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(lowerGroundTiles[i].transform.position.x, lowerGroundTiles[i].transform.position.y, lowerGroundTiles[i].transform.position.z - 1);
                indexIncrement++;
            }

            if (lowerGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[0] == 1)
            {
                edgeOfStageTiles[indexIncrement].transform.position = new Vector3(lowerGroundTiles[i].transform.position.x - 1, lowerGroundTiles[i].transform.position.y, lowerGroundTiles[i].transform.position.z);
                indexIncrement++;
            }
        }
    }

    private void PlaceHigherGroundTilesRandomly()
    {
        for (int i = 0; i < numberOfHigherGroundTiles; i++)
        {
            higherGroundTiles.Add(Instantiate(higherGround));

            GameObject selectedTile = lowerGroundTiles[Random.Range(0, lowerGroundTiles.Count)];

            higherGroundTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1, selectedTile.transform.position.z);

            higherGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            higherGroundTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];


            lowerGroundTiles.RemoveAt(lowerGroundTiles.IndexOf(selectedTile));
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
            GameObject selectedTile = lowerGroundTiles[Random.Range(0, lowerGroundTiles.Count)];

            bottomlessPitTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 0.5f, selectedTile.transform.position.z);

            bottomlessPitTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
            bottomlessPitTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

            Destroy(lowerGroundTiles[lowerGroundTiles.IndexOf(selectedTile)]);
            lowerGroundTiles.RemoveAt(lowerGroundTiles.IndexOf(selectedTile));
        }
    }

    private void PlacePlayerSpawns()
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
                GameObject selectedTile = lowerGroundTiles[Random.Range(0, lowerGroundTiles.Count)];

                playerSpawnTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1.5f, selectedTile.transform.position.z);

                playerSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
                playerSpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

                lowerGroundTiles.RemoveAt(lowerGroundTiles.IndexOf(selectedTile));
            }
        }
    }

    private void PlaceEnemySpawns()
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
                GameObject selectedTile = lowerGroundTiles[Random.Range(0, lowerGroundTiles.Count)];

                enemySpawnTiles[i].transform.position = new Vector3(selectedTile.transform.position.x, 1.5f, selectedTile.transform.position.z);

                enemySpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[0] = selectedTile.GetComponent<StageEditor>().tileCoordinates[0];
                enemySpawnTiles[i].GetComponent<StageEditor>().tileCoordinates[1] = selectedTile.GetComponent<StageEditor>().tileCoordinates[1];

                lowerGroundTiles.RemoveAt(lowerGroundTiles.IndexOf(selectedTile));
            }
        }
    }

    private void DestroyStage()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("HigherGround").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("HigherGround")[i]);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("LowerGround").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("LowerGround")[i]);
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

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("PlayerSpawn").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("PlayerSpawn")[i]);
        }

        higherGroundTiles.Clear();
        lowerGroundTiles.Clear();
        edgeOfStageTiles.Clear();
        bottomlessPitTiles.Clear();
        enemySpawnTiles.Clear();
        playerSpawnTiles.Clear();
    }

    private void UpdateEditorValues()
    {
        stageWidthEditor = stageWidth;
        stageHeightEditor = stageHeight;
        numberOfHigherGroundTilesEditor = numberOfHigherGroundTiles;
        numberOfBottomlessPitsEditor = numberOfBottomlessPits;
        numberOfEnemySpawnsEditor = numberOfEnemySpawns;
        numberOfPlayerSpawnsEditor = numberOfPlayerSpawns;
    }

    private void UpdatePrivateStageValues()
    {
        stageWidth = stageWidthEditor;
        stageHeight = stageHeightEditor;
        numberOfHigherGroundTiles = numberOfHigherGroundTilesEditor;
        numberOfBottomlessPits = numberOfBottomlessPitsEditor;
        numberOfEnemySpawns = numberOfEnemySpawnsEditor;
        numberOfPlayerSpawns = numberOfPlayerSpawnsEditor;

        regenerateStage = false;
    }

    public void RegenerateStage()
    {
        regenerateStage = true;
    }
}
