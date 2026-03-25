using UnityEngine;

public class Station3Cam : MonoBehaviour
{
    [Header("Camera Switch")]
    public GameObject currentCamera;
    public GameObject station3Camera;

    [Header("Dough Transfer")]
    public GameObject cutDoughObject;
    public Transform doughSpawnPoint;

    [Header("Optional Objects To Show")]
    public GameObject[] objectsToEnable;

    [Header("Optional Objects To Hide")]
    public GameObject[] objectsToDisable;

    public void SwitchToStation3()
    {
        if (currentCamera != null)
        {
            currentCamera.SetActive(false);
        }

        if (station3Camera != null)
        {
            station3Camera.SetActive(true);
        }

        if (cutDoughObject != null && doughSpawnPoint != null)
        {
            cutDoughObject.transform.position = doughSpawnPoint.position;
            Debug.Log("Cut dough moved to Station 3.");
        }
        else
        {
            Debug.LogWarning("Cut dough object or dough spawn point is missing.");
        }

        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        gameObject.SetActive(false);

        Debug.Log("Switched to Station 3 camera.");
    }
}
