using System.Collections.Generic;
using UnityEngine;

public class BowlDropZone : MonoBehaviour
{
    [Header("Settings")]
    public string draggableTag = "Draggable";
    public Transform dropPoint;
    public float detectionRadius = 0.5f;
    public bool disableDroppedObjects = true;

    private HashSet<GameObject> processedObjects = new HashSet<GameObject>();

    private void Update()
    {
        DetectObjects();
    }

    void DetectObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider col in hits)
        {
            if (!col.CompareTag(draggableTag)) continue;
            if (processedObjects.Contains(col.gameObject)) continue;

            HandleDrop(col.gameObject);
            processedObjects.Add(col.gameObject);
        }
    }

    void HandleDrop(GameObject obj)
    {
        if (dropPoint != null)
        {
            obj.transform.position = dropPoint.position;
        }

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        DragPlaneFix dragScript = obj.GetComponent<DragPlaneFix>();
        if (dragScript != null)
        {
            dragScript.enabled = false;
        }

        if (disableDroppedObjects)
        {
            obj.SetActive(false);
            Debug.Log("Object dropped into bowl and was hidden.");
        }
        else
        {
            Debug.Log("Object dropped into bowl, but it was not hidden.");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
