using UnityEngine;
using UnityEngine.EventSystems;

public class DebugDraggableIngredient : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Camera tableCamera;
    public bool canDrag = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        if (tableCamera == null)
            Debug.LogWarning(name + ": tableCamera not assigned!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(name + ": OnBeginDrag called");

        if (!canDrag)
        {
            Debug.Log(name + ": cannot drag yet (canDrag = false)");
            return;
        }

        Debug.Log(name + ": drag started");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag)
            return;

        if (tableCamera == null)
            return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(tableCamera.transform.position, transform.position);
        transform.position = tableCamera.ScreenToWorldPoint(mousePos);

        Debug.Log(name + ": dragging at " + transform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(name + ": OnEndDrag called");
    }
}