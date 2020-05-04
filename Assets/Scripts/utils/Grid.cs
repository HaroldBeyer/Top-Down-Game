using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;

public class Grid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private Vector3 originPosition;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.height = height;
        this.width = width;
        this.originPosition = originPosition;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                debugTextArray[i, z] = UtilsClass.CreateWorldText(gridArray[i, z].ToString(), null, getWorldPosition(i, z) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(getWorldPosition(i, z), getWorldPosition(i, z + 1), Color.white, 100f);
                Debug.DrawLine(getWorldPosition(i, z), getWorldPosition(i + 1, z), Color.white, 100f);
            }
        }
        Debug.DrawLine(getWorldPosition(0, height), getWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.white, 100f);

        // setValue(2, 1, 56);

    }
    private Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void setValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    private void getXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void setValue(Vector3 worldPosition, int value)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        setValue(x, y, value);
    }

    public int getValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        return 0;
    }

    public int getValue(Vector3 worldPosition)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        return getValue(x, y);
    }
}