using UnityEngine;

public class BowlDropZone : MonoBehaviour
{
    [Header("Settings")]
    public string draggableTag = "Draggable";
    public Transform dropPoint;
    public float detectionRadius = 0.5f;

    private void Update()
    {
        DetectObjects();
    }

    void DetectObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider col in hits)
        {
            if (col.CompareTag(draggableTag))
            {
                HandleDrop(col.gameObject);
            }
        }
    }

    void HandleDrop(GameObject obj)
    {
        // Snap to drop point if assigned
        if (dropPoint != null)
        {
            obj.transform.position = dropPoint.position;
        }

        obj.SetActive(false);

        Debug.Log("Object dropped into bowl!");
    }

    // Optional: visualize detection radius in editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}