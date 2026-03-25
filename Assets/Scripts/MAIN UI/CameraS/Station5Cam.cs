using UnityEngine;

public class Station5Cam : MonoBehaviour
{
    [Header("Camera Switch")]
    public GameObject currentCamera;
    public GameObject station5Camera;

    [Header("Optional Objects To Show")]
    public GameObject[] objectsToEnable;

    [Header("Optional Objects To Hide")]
    public GameObject[] objectsToDisable;

    public void SwitchToStation5()
    {
        if (currentCamera != null)
        {
            currentCamera.SetActive(false);
        }

        if (station5Camera != null)
        {
            station5Camera.SetActive(true);
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

        Debug.Log("Switched to Station 5 camera.");
    }
}
