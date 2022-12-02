using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public Transform gridStartPosition;
    [SerializeField]private int columnLength = 0;
    [SerializeField]private int rowLength = 0;

    private void Awake()
    {
        BlockManager blockManager = GameManager.Instance.blockManager;
        Cell gridCell;

        for(int column = 0; column < columnLength; column++)
        {
            for(int row = 0; row < rowLength; row++)
            {
                gridCell = new Cell(row, column);
                blockManager.createBlock(gridCell);
            }
        }

        setBlockGroups();
    }

    public void setBlockGroups()
    {
        
    }

    private BlockTypes type()
    {
        int rndm = Random.Range(1, 3);
        
        switch (rndm)
        {
            case 2:
                return BlockTypes.Dynamiet;
            default:
                return BlockTypes.Standard;
        }
    }
}