using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cellPrefab;

    public CellScript[,] grid;

    int gridWidth = 100;
    int gridHeight = 100;

    //float cellWidth = 0.8f;
    //float cellHeight = 0.8f;

    float cellDimension = 0.8f;
    float padding = 0.5f;

    float timer = 0;
    float timerRate = 0.5f;
    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        grid = new CellScript[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                Vector3 pos = new Vector3(x * (cellDimension + padding), 0, y * (cellDimension + padding));
                GameObject cellObj = Instantiate(cellPrefab, pos, Quaternion.identity); // Don't rotate.
                cellObj.transform.localScale = new Vector3(cellDimension, cellDimension, cellDimension); // Square
                CellScript cs = cellObj.GetComponent<CellScript>();
                cs.x = x;
                cs.y = y;
                grid[x, y] = cs;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) {
            generateNextState();

            timer = timerRate;
        }
    }

    void generateNextState() {
        time++;

        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                List<CellScript> liveNeighbors = gatherLiveNeighbors(x, y);
                if (!grid[x, y].Alive && liveNeighbors.Count == 3) {
                    grid[x, y].nextAlive = true;
                }
            }
        }
    }

    List<CellScript> gatherLiveNeighbors(int x, int y) {
        List<CellScript> liveNeighbors = new List<CellScript>();
        for (int i = x - 1; i <= x + 1; i++) {
            for (int j = y - 1; j <= y + 1; j++) {
                if (!(x == i && y == j)) {
                    if (grid[i, j].Alive) {
                        liveNeighbors.Add(grid[i, j]);
                    }
                }
            }
        }

        return liveNeighbors;
    }
}
