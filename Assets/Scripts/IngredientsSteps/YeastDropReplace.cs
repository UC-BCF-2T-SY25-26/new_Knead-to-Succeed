using UnityEngine;

public class YeastDropReplace : MonoBehaviour
{
    [Header("Replacement Prefab")]
    public GameObject activatedYeastPrefab;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public Transform parentAfterSpawn;

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

            if (activatedYeastPrefab == null)
            {
                Debug.LogWarning("No activatedYeastPrefab assigned on " + gameObject.name);
            }
            else
            {
                Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
                Quaternion spawnRotation = spawnPoint != null ? spawnPoint.rotation : transform.rotation;

                GameObject spawnedYeast = Instantiate(activatedYeastPrefab, spawnPosition, spawnRotation);

                if (parentAfterSpawn != null)
                {
                    spawnedYeast.transform.SetParent(parentAfterSpawn, true);
                }
                else
                {
                    spawnedYeast.transform.SetParent(other.transform, true);
                }

                Debug.Log("Spawned yeast at: " + spawnedYeast.transform.position);
            }

            Destroy(gameObject);

            Debug.Log("Yeast dropped into bowl and replaced!");
        }
    }
}
