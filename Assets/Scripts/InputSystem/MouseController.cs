using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private ICommand command;

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            selectHandler();
        }
    }

    void selectHandler()
    {
        if(getRaycastHitCollider())
        {
            GameObject selectedGameObject = getRaycastHitCollider().gameObject;
            command = new SelectCommand();

            command.execute(selectedGameObject.GetComponent<BlockBehaviour>());
        }
    }

    private Collider2D getRaycastHitCollider()
    {
        Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, Vector2.zero);

        return raycastHit2D.collider;
    }
}