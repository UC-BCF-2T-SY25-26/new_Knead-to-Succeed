using UnityEngine;

public class ReturnToMainCam : MonoBehaviour
{
    [Header("Camera Switch")]
    public GameObject currentCamera;
    public GameObject mainCamera;

    [Header("Optional Objects To Show")]
    public GameObject[] objectsToEnable;

    [Header("Optional Objects To Hide")]
    public GameObject[] objectsToDisable;

    public void SwitchToMainCamera()
    {
        if (currentCamera != null)
        {
            currentCamera.SetActive(false);
        }

        if (mainCamera != null)
        {
            mainCamera.SetActive(true);
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

        Debug.Log("Returned to main camera.");
    }
}
