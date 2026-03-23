using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DragPlaneFix : MonoBehaviour
{
    private Camera cam;
    private Plane dragPlane;
    private Vector3 offset;
    private bool isDragging;

    private Vector3 velocity;
    public float damping = 5f;

    [Header("Settings")]
    public bool useCameraFacingPlane = true; // makes dragging feel natural
    public bool useRigidbody = false;        // optional physics support

    private Rigidbody rb;

    void Awake()
    {
        cam = Camera.main;

        if (useRigidbody)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void OnMouseDown()
    {
        // Choose plane direction
        Vector3 planeNormal = useCameraFacingPlane 
            ? cam.transform.forward 
            : Vector3.forward;

        dragPlane = new Plane(planeNormal, transform.position);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            offset = transform.position - hitPoint;
        }

        velocity = Vector3.zero;
        isDragging = true;

        if (rb != null)
            rb.isKinematic = true; // disable physics while dragging
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 targetPos = hitPoint + offset;

            velocity = (targetPos - transform.position) / Time.deltaTime;

            if (rb != null)
                rb.MovePosition(targetPos);
            else
                transform.position = targetPos;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (rb != null)
            rb.isKinematic = false;
    }

    void Update()
    {
        if (!isDragging && velocity.magnitude > 0.01f)
        {
            if (rb != null)
                rb.MovePosition(rb.position + velocity * Time.deltaTime);
            else
                transform.position += velocity * Time.deltaTime;

            velocity = Vector3.Lerp(velocity, Vector3.zero, damping * Time.deltaTime);
        }
    }
}