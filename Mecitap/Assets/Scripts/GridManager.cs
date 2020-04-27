﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   
    [SerializeField]
    private int rows = 5;
    [SerializeField] 
    private int cols = 5;
    [SerializeField]
    private float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        //mengambil asset white (png 1x1 berwarna putih) sebagai 
        GameObject referenceFrame = (GameObject)Instantiate(Resources.Load("white"));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tileFrame = (GameObject)Instantiate(referenceFrame, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tileFrame.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceFrame);

        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;
        transform.position = new Vector2(-gridWidth / 2 + tileSize / 2, gridHeight / 2 - tileSize / 2);
    }

}
