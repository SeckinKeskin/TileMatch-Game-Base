using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject blockObject;
    [SerializeField] private ScriptableBlockObject[] scriptableBlocks;
    [SerializeField] private GameObject gridParent;
    private Block block;
    private GameObject cloneBlockObject;
    private BlockBehaviour blockBehaviour;
    private List<ScriptableBlockObject> standardBlockObjectList = new List<ScriptableBlockObject>();

    public void Start()
    {
        setBlockListByType(BlockTypes.Standard);
    }

    public void createBlock(Cell cell, BlockTypes type = BlockTypes.Standard)
    {
        switch (type)
        {
            case BlockTypes.Dynamite:
                block = new DynamiteBlock();
                break;
            default:
                block = new StandardBlock();
                break;
        }

        block.create(cell);
        block.initialize();
        instantiateBlock();
    }

    public void instantiateBlock()
    {
        cloneBlockObject = Instantiate(blockObject, transform.position, Quaternion.identity);
        cloneBlockObject.transform.parent = gridParent.transform;
        blockBehaviour = cloneBlockObject.GetComponent<BlockBehaviour>();
        blockBehaviour.block = block;

        blockBehaviour.setup();
        GameManager.Instance.inGameBlockList.Add(blockBehaviour);
    }

    public ScriptableBlockObject getBlockByType(BlockTypes type)
    {
        foreach (ScriptableBlockObject scriptableBlock in scriptableBlocks)
        {
            if (scriptableBlock.type == type)
                return scriptableBlock;
        }

        Debug.Log("Block is not set any type!");
        return null;    //Need Error Handler! Check!
    }

    public ScriptableBlockObject randomizeScriptableObject(BlockTypes type = BlockTypes.Standard)
    {
        if (standardBlockObjectList.Count == 0)
            setBlockListByType(type);

        int rndm = Random.Range(0, standardBlockObjectList.Count);

        return standardBlockObjectList[rndm];
    }

    public void setBlockListByType(BlockTypes type)
    {
        foreach (ScriptableBlockObject scriptableBlock in scriptableBlocks)
        {
            if (scriptableBlock.type == type)
            {
                standardBlockObjectList.Add(scriptableBlock);
            }
        }
    }
    public BlockBehaviour getBlockBehaviour(int column, int row)
    {
        List<BlockBehaviour> blockList = GameManager.Instance.inGameBlockList;

        foreach (BlockBehaviour behaviour in blockList)
        {
            if (behaviour.block.grid.column == column && behaviour.block.grid.row == row)
                return behaviour;
        }

        return null;    //Need Error Handler! Check!
    }

    public void resetBlocks()
    {

    }

    public List<BlockBehaviour> getEntireColumnBlocks(int blockColumn)
    {
        List<BlockBehaviour> inGameBlocks = GameManager.Instance.inGameBlockList;
        List<BlockBehaviour> entireColumn = new List<BlockBehaviour>();

        foreach (BlockBehaviour behaviour in inGameBlocks)
        {
            if (behaviour.block.grid.column == blockColumn)
            {
                entireColumn.Add(behaviour);
            }
        }

        return entireColumn;
    }

    public List<BlockBehaviour> getEntireColumnBlocks(int blockColumn, int rowLimit)
    {
        List<BlockBehaviour> inGameBlocks = GameManager.Instance.inGameBlockList;
        List<BlockBehaviour> entireColumn = new List<BlockBehaviour>();

        foreach (BlockBehaviour behaviour in inGameBlocks)
        {
            if (behaviour.block.grid.column == blockColumn && behaviour.block.grid.row <= rowLimit)
            {
                entireColumn.Add(behaviour);
            }
        }

        return entireColumn;
    }

    public List<BlockBehaviour> getEntireRowBlocks(int blockRow)
    {
        List<BlockBehaviour> inGameBlocks = GameManager.Instance.inGameBlockList;
        List<BlockBehaviour> entireRow = new List<BlockBehaviour>();

        foreach (BlockBehaviour behaviour in inGameBlocks)
        {
            if (behaviour.block.grid.row == blockRow)
            {
                entireRow.Add(behaviour);
            }
        }

        return entireRow;
    }

    public List<BlockBehaviour> getEntireRowBlocks(int blockRow, int columnLimit)
    {
        List<BlockBehaviour> inGameBlocks = GameManager.Instance.inGameBlockList;
        List<BlockBehaviour> entireRow = new List<BlockBehaviour>();

        foreach (BlockBehaviour behaviour in inGameBlocks)
        {
            if (behaviour.block.grid.row == blockRow && behaviour.block.grid.column <= columnLimit)
            {
                entireRow.Add(behaviour);
            }
        }

        return entireRow;
    }
}