using UnityEngine;

[CreateAssetMenu(fileName = "BlockTypeData", menuName = "Scriptable Object/Block", order = 1)]
public class ScriptableBlockObject : ScriptableObject
{
    public Sprite sprite;
    public BlockTypes type = BlockTypes.Standard;
    public BlockColors blockColor = BlockColors.None;
}
