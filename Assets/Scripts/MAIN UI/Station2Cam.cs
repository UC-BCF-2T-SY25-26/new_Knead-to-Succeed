using UnityEngine;

public class Station2Cam : MonoBehaviour
{
    [Header("Camera Switch")]
    public GameObject currentCamera;
    public GameObject station2Camera;

    [Header("Bowl Transfer")]
    public GameObject bowlObject;
    public Transform bowlSpawnPoint;
    public GameObject doughPrefab;

    public void SwitchToStation2()
    {
        if (currentCamera != null)
        {
            currentCamera.SetActive(false);
        }

        if (station2Camera != null)
        {
            station2Camera.SetActive(true);
        }

        if (bowlObject != null && bowlSpawnPoint != null)
        {
            bowlObject.transform.position = bowlSpawnPoint.position;
            bowlObject.transform.rotation = bowlSpawnPoint.rotation;

            for (int i = bowlObject.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(bowlObject.transform.GetChild(i).gameObject);
            }

            if (doughPrefab != null)
            {
                GameObject spawnedDough = Instantiate(
                    doughPrefab,
                    bowlObject.transform.position,
                    bowlObject.transform.rotation
                );

                spawnedDough.transform.SetParent(bowlObject.transform, true);

                Debug.Log("Dough instantiated inside bowl.");
            }
            else
            {
                Debug.LogWarning("No doughPrefab assigned.");
            }

            Debug.Log("Bowl moved to Station 2.");
        }
        else
        {
            Debug.LogWarning("BowlObject or BowlSpawnPoint is missing.");
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        gameObject.SetActive(false);

        Debug.Log("Switched to Station 2 camera.");
    }
}
