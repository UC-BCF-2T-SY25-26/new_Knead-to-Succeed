using UnityEngine;

public class DragPlaneFix : MonoBehaviour
{
    private Camera cam;
    private Plane dragPlane;
    private Vector3 offset;
    private bool isDragging;

    private Vector3 velocity;          // Tracks movement speed
    public float damping = 5f;         // How fast it slows down after release

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(Vector3.forward, transform.position);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            offset = transform.position - hitPoint;
        }

        velocity = Vector3.zero; // reset velocity
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 targetPos = hitPoint + offset;

            // Calculate velocity based on movement
            velocity = (targetPos - transform.position) / Time.deltaTime;

            transform.position = targetPos;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        // Apply inertia when not dragging
        if (!isDragging && velocity.magnitude > 0.01f)
        {
            transform.position += velocity * Time.deltaTime;

            // Smoothly reduce velocity
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping * Time.deltaTime);
        }
    }
}