using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableIngredient : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    public Camera tableCamera; // assign table camera in Inspector
    public bool canDrag = false; // enabled after pressing E at table

    void Start()
    {
        startPos = transform.position;
        canDrag = true; // TEMP for testing
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag || tableCamera == null) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(tableCamera.transform.position, transform.position);
        transform.position = tableCamera.ScreenToWorldPoint(mousePos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Drop handled by BowlDropZone
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}