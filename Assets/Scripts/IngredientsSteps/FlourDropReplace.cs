using UnityEngine;

public class FlourDropReplace : MonoBehaviour
{
    [Header("Flour Prefabs")]
    public GameObject pouredFlourPrefab;
    public Transform spawnPoint;
    public Transform parentAfterSpawn;
    public string dropZoneTag = "DropZone";

    private bool hasDropped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDropped) return;

        if (other.CompareTag(dropZoneTag))
        {
            hasDropped = true;

            if (pouredFlourPrefab != null)
            {
                Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
                Quaternion spawnRotation = spawnPoint != null ? spawnPoint.rotation : transform.rotation;

                GameObject spawnedFlour = Instantiate(pouredFlourPrefab, spawnPosition, spawnRotation);

                if (parentAfterSpawn != null)
                {
                    spawnedFlour.transform.SetParent(parentAfterSpawn, true);
                }
                else
                {
                    spawnedFlour.transform.SetParent(other.transform, true);
                }

                Debug.Log("Spawned flour at: " + spawnedFlour.transform.position);
            }

            if (TutorialManager.Instance != null)
            {
                TutorialManager.Instance.NextStep();
            }

            Destroy(gameObject);

            Debug.Log("Flour dropped into bowl and replaced!");
        }
    }
}
