using UnityEngine;

public class DragPlaneFix : MonoBehaviour
{
    private Camera cam;
    private Plane dragPlane;
    private Vector3 offset;
    private bool isDragging;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        // Create a plane at the object's height facing the camera
        dragPlane = new Plane(Vector3.forward, transform.position);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            offset = transform.position - hitPoint;
        }

        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            transform.position = hitPoint + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}