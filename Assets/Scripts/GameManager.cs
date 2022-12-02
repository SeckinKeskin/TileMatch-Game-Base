using UnityEngine;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public GridManager gridManager;
    public BlockManager blockManager;
    public List<BlockBehaviour> inGameBlockList = new List<BlockBehaviour>();
}