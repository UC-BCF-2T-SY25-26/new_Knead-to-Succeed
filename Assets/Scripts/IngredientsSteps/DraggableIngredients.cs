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
    public bool useCameraFacingPlane = true;
    public bool useRigidbody = false;

    [Header("Drag Filter")]
    public string requiredTag = "Draggable";

    [Header("Debug")]
    public bool debugRaycast = true;

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
        if (!CompareTag(requiredTag))
        {
            if (debugRaycast)
            {
                Debug.Log(gameObject.name + " is not draggable because it does not have tag: " + requiredTag);
            }
            return;
        }

        if (debugRaycast)
        {
            Debug.Log("Clicked draggable object: " + gameObject.name);
        }

        Vector3 planeNormal = useCameraFacingPlane ? cam.transform.forward : Vector3.forward;
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
        {
            rb.isKinematic = true;
        }
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 targetPos = hitPoint + offset;

            velocity = (targetPos - transform.position) / Mathf.Max(Time.deltaTime, 0.0001f);

            if (rb != null)
            {
                rb.MovePosition(targetPos);
            }
            else
            {
                transform.position = targetPos;
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    void Update()
    {
        if (debugRaycast && Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Mouse raycast hit: " + hit.collider.gameObject.name);
            }
        }

        if (!isDragging && velocity.magnitude > 0.01f)
        {
            if (rb != null)
            {
                rb.MovePosition(rb.position + velocity * Time.deltaTime);
            }
            else
            {
                transform.position += velocity * Time.deltaTime;
            }

            velocity = Vector3.Lerp(velocity, Vector3.zero, damping * Time.deltaTime);
        }
    }
}
