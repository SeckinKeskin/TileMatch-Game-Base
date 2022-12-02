using UnityEngine;

public abstract class Block
{
    public Cell grid;
    public string name;
    public Sprite sprite;
    public Vector2 position;
    public IBlock iBlock;
    public BlockColors color = BlockColors.None;
    public BlockTypes type = BlockTypes.None;
    public abstract void create(Cell cell);
    public abstract void initialize();
    public void setPosition()
    {
        float gridPosX = GameManager.Instance.gridManager.gridStartPosition.position.x;
        float gridPosY = GameManager.Instance.gridManager.gridStartPosition.position.y;
        float margin = 0.65f;

        position.x = gridPosX + (grid.column * margin);
        position.y = gridPosY - (grid.row * margin);
    }

    public void setName()
    {
        name = type + " Block " + grid.column + "x" + grid.row + " Color-" + color;
    }
}