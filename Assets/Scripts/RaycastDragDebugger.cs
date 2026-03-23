using UnityEngine;

public class RaycastDragDebugger : MonoBehaviour
{
    private Camera cam;
    private Transform selectedObject;
    private Vector3 offset;
    private float zDistance;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // 🔴 VISUAL DEBUG RAY
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("HIT: " + hit.collider.name);

                selectedObject = hit.transform;
                zDistance = cam.WorldToScreenPoint(selectedObject.position).z;

                Vector3 mousePos = Input.mousePosition;
                mousePos.z = zDistance;

                offset = selectedObject.position - cam.ScreenToWorldPoint(mousePos);
            }
            else
            {
                Debug.Log("NO HIT detected under mouse");
            }
        }

        if (Input.GetMouseButton(0) && selectedObject != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = zDistance;

            selectedObject.position = cam.ScreenToWorldPoint(mousePos) + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
    }
}