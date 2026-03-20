using UnityEngine;

public class CameraRayDebug : MonoBehaviour
{
    public float rayDistance = 100f; // how far the ray checks

    void Update()
    {
        // Cast a ray from the mouse position
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log("Ray hit: " + hit.collider.name);
        }

        // Optional: draw the ray in Scene view
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
    }
}