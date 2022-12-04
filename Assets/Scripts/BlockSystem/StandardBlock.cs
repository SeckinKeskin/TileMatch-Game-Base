using UnityEngine;
using System.Collections.Generic;

public class StandardBlock : Block, IBlock
{
    public List<BlockBehaviour> neighborBlockList;
    public List<BlockBehaviour> explodeList;
    private Vector2[] neighborSides = { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
    private ScriptableBlockObject scriptableBlockObject;
    private BlockManager blockManager = GameManager.Instance.blockManager;

    #region Standard Type Getters
    private Sprite getSprite()
    {
        return scriptableBlockObject.sprite;
    }

    private BlockColors getBlockColor()
    {
        return scriptableBlockObject.blockColor;
    }
    #endregion
    #region Set Scriptable Block
    /// <summary>
    /// First of all set one scriptable block for will be created block.
    /// </summary>
    private void setScriptableBlock()
    {
        scriptableBlockObject = blockManager.randomizeScriptableObject();
    }
    #endregion

    public override void create(Cell cell)
    {
        grid = cell;
        setScriptableBlock();
    }

    public override void initialize()
    {
        iBlock = this;
        sprite = getSprite();
        color = getBlockColor();
        type = BlockTypes.Standard;

        setPosition();
        setName();
    }

    public void explode(BlockBehaviour behaviour)
    {
        explodeList = new List<BlockBehaviour>();
        explodeList.Add(behaviour);

        setExplodeList();
        reposition();
    }

    private void reposition()
    {
        int newRow = -1;
        int oldRow = 0;

        foreach (BlockBehaviour blockBehaviour in explodeList)
        {
            oldRow = blockBehaviour.block.grid.row;
            blockBehaviour.block.grid.row = newRow;

            blockBehaviour.block.setPosition();
            blockBehaviour.setup();

            rePositionAllColumn(blockBehaviour.block.grid.column, oldRow);
        }
    }

    private void rePositionAllColumn(int column, int rowLimit)
    {
        List<BlockBehaviour> entireColumn = blockManager.getEntireColumnBlocks(column, rowLimit);

        foreach (BlockBehaviour blockBehaviour in entireColumn)
        {
            blockBehaviour.block.grid.column = column;
            blockBehaviour.block.grid.row = blockBehaviour.block.grid.row + 1;

            blockBehaviour.block.setPosition();
            blockBehaviour.setup();
        }
    }

    private void setExplodeList()
    {
        BlockBehaviour blockBehaviour;
        BlockBehaviour explodeListBehaviour;

        int neighborColumn = 0;
        int neighborRow = 0;

        for (int i = 0; i < explodeList.Count; i++)
        {
            explodeListBehaviour = explodeList[i];

            foreach (Vector2 side in neighborSides)
            {
                neighborColumn = explodeListBehaviour.block.grid.column + (int)side.x;
                neighborRow = explodeListBehaviour.block.grid.row + (int)side.y;

                blockBehaviour = blockManager.getBlockBehaviour(neighborColumn, neighborRow);

                if (blockBehaviour && !isAlreadyInExplodeList(blockBehaviour) && blockBehaviour.block.color == color)
                {
                    explodeList.Add(blockBehaviour);
                }
            }
        }
    }

    private bool isAlreadyInExplodeList(BlockBehaviour blockBehaviour)
    {
        foreach (BlockBehaviour behaviour in explodeList)
        {
            if (behaviour == blockBehaviour)     //List find is it usable? Check!
            {
                return true;
            }
        }

        return false;
    }
}