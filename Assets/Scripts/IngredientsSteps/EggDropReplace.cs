using UnityEngine;

public class EggDropReplace : MonoBehaviour
{
    [Header("Replacement Prefab")]
    public GameObject crackedEggPrefab;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public Transform parentAfterSpawn;
    public Vector3 spawnRotationEuler = new Vector3(-3.58f, -144.3f, 0f);

    [Header("Drop Settings")]
    public string dropZoneTag = "DropZone";

    private bool hasDropped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDropped) return;
        if (!other.CompareTag(dropZoneTag)) return;

        hasDropped = true;

        if (crackedEggPrefab == null)
        {
            Debug.LogWarning("No crackedEggPrefab assigned on " + gameObject.name);
        }
        else
        {
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
            Quaternion spawnRotation = Quaternion.Euler(spawnRotationEuler);

            GameObject spawnedEgg = Instantiate(crackedEggPrefab, spawnPosition, spawnRotation);

            if (parentAfterSpawn != null)
            {
                spawnedEgg.transform.SetParent(parentAfterSpawn, true);
            }
            else
            {
                spawnedEgg.transform.SetParent(other.transform, true);
            }

            Debug.Log("Spawned egg at: " + spawnedEgg.transform.position);
        }

        Destroy(gameObject);
    }
}
