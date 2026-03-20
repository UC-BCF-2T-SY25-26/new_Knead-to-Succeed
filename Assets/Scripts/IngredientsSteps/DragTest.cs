using UnityEngine;

public class DragTest : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("[TEST] CLICKED: " + gameObject.name);
    }

    void OnMouseDrag()
    {
        Debug.Log("[TEST] DRAGGING: " + gameObject.name);
    }

    void OnMouseUp()
    {
        Debug.Log("[TEST] RELEASED: " + gameObject.name);
    }
}