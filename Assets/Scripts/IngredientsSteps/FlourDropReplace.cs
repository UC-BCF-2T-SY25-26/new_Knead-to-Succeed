using UnityEngine;

public class FlourDropReplace : MonoBehaviour
{
    [Header("Flour Prefabs")]
    public GameObject pouredFlourPrefab; // The object to appear after drop
    public string dropZoneTag = "DropZone"; // Tag of the bowl or target

    private bool hasDropped = false;

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger once
        if (hasDropped) return;

        // Check if it hit the drop zone
        if (other.CompareTag(dropZoneTag))
        {
            hasDropped = true;

            // Optional: spawn the replacement prefab at the same position
            if (pouredFlourPrefab != null)
            {
                Instantiate(
                    pouredFlourPrefab,
                    transform.position,
                    transform.rotation
                );
            }

            // Remove original flour
            Destroy(gameObject);

            Debug.Log("Flour dropped into bowl and replaced!");
        }
    }
}