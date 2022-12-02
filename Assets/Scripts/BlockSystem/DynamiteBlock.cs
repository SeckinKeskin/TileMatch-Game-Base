using UnityEngine;

public class DynamiteBlock : Block, IBlock
{
    private ScriptableBlockObject scriptableBlockObject;
    
    public DynamiteBlock()
    {
        setScriptableBlock();
    }
    
    public override void create(Cell cell)
    {
        
    }
    public override void initialize()
    {
        throw new System.NotImplementedException();
    }

    private Sprite getSprite()
    {
        return scriptableBlockObject.sprite;
    }

    private void setScriptableBlock()
    {
        BlockManager blockManager = new BlockManager();
        scriptableBlockObject = blockManager.getBlockByType(BlockTypes.Dynamite);
    }

    public void explode(BlockBehaviour behaviour)
    {
        Debug.Log("Block : "+ grid.column + "x" + grid.row);
    }
}