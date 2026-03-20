using UnityEngine;

public class BowlDropZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Draggable"))
        {
            // Optional: snap before disappearing
            other.transform.position = transform.position;

            // Make it disappear
            Destroy(other.gameObject);
        }
    }
}