using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class BlockBehaviour : MonoBehaviour
{
    public Block block;

    public void setup()
    {
        setSprite();
        setPosition();
        setName();
    }
    public void setSprite()
    {
        GetComponent<SpriteRenderer>().sprite = block.sprite;
    }
    public void setPosition()
    {
        transform.position = block.position;
    }
    public void setName()
    {
        transform.name = block.name;
    }
}
