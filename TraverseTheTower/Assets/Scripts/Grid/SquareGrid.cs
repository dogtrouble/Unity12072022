using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid : MonoBehaviour
{
    public int height = 8;
    public int width  = 8;

    public SquareCell cellPrefab;
    SquareCell[] cells;

    private void Awake()
    {
        cells = new SquareCell[width * height];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int i) 
    {
        Vector3 position;
        position.x = x * 10;
        position.y = 0f;
        position.z = z * 10;

        SquareCell cell = cells[i] = Instantiate<SquareCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
}
