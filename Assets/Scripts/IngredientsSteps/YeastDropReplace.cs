using UnityEngine;

public class YeastDropReplace : MonoBehaviour
{
    [Header("Replacement Prefab")]
    public GameObject activatedYeastPrefab; // what appears after drop

    [Header("Drop Settings")]
    public string dropZoneTag = "DropZone";

    private bool hasDropped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDropped) return;

        if (other.CompareTag(dropZoneTag))
        {
            hasDropped = true;

            Debug.Log("Yeast entered drop zone: " + other.name);

            if (activatedYeastPrefab != null)
            {
                Instantiate(
                    activatedYeastPrefab,
                    transform.position,
                    transform.rotation
                );
            }
            else
            {
                Debug.LogWarning("No activatedYeastPrefab assigned!");
            }

            Destroy(gameObject);
        }
    }
}