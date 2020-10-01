using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cellPrefab;

    int gridWidth = 100;
    int gridHeight = 100;

    //float cellWidth = 0.8f;
    //float cellHeight = 0.8f;

    float cellDimension = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                Vector3 pos = new Vector3(x * cellDimension, 0, y * cellDimension);
                GameObject cellObj = Instantiate(cellPrefab, pos, Quaternion.identity); // Don't rotate.
                cellObj.transform.localScale = new Vector3(cellDimension, cellDimension, cellDimension); // Square
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
