using UnityEngine;

public class EggReplace : MonoBehaviour
{
    [Header("Cracked Egg Prefab")]
    public GameObject crackedEggPrefab;

    [Header("Spawn Settings")]
    public Transform spawnPoint; // optional (if null, uses current position)

    private bool hasReplaced = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        if (hasReplaced)
        {
            Debug.Log("Already replaced, ignoring trigger.");
            return;
        }

        if (other.CompareTag("dropZone"))
        {
            Debug.Log("DropZone detected!");

            SpawnCrackedEgg();

            hasReplaced = true;

            // Hide original egg
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Entered trigger but not dropZone: " + other.tag);
        }
    }

    void SpawnCrackedEgg()
    {
        if (crackedEggPrefab == null)
        {
            Debug.LogError("❌ Cracked Egg Prefab is NOT assigned in Inspector!");
            return;
        }

        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : transform.position;
        Quaternion spawnRot = spawnPoint != null ? spawnPoint.rotation : transform.rotation;

        GameObject newEgg = Instantiate(crackedEggPrefab, spawnPos, spawnRot);

        if (newEgg != null)
        {
            Debug.Log("✅ Cracked egg spawned successfully!");
        }
        else
        {
            Debug.LogError("❌ Failed to spawn cracked egg!");
        }
    }
}