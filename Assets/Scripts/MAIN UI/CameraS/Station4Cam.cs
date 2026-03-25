using UnityEngine;

public class Station4Cam : MonoBehaviour
{
    [Header("Camera Switch")]
    public GameObject currentCamera;
    public GameObject station4Camera;

    [Header("Pre-Placed Objects")]
    public GameObject butteredTrayObject;
    public GameObject trayDoughPiecesObject;

    [Header("Optional Objects To Show")]
    public GameObject[] objectsToEnable;

    [Header("Optional Objects To Hide")]
    public GameObject[] objectsToDisable;

    public void SwitchToStation4()
    {
        if (currentCamera != null)
        {
            currentCamera.SetActive(false);
        }

        if (station4Camera != null)
        {
            station4Camera.SetActive(true);
        }

        if (butteredTrayObject != null)
        {
            butteredTrayObject.SetActive(true);
            Debug.Log("Buttered tray enabled.");
        }

        if (trayDoughPiecesObject != null)
        {
            trayDoughPiecesObject.SetActive(true);
            Debug.Log("Tray dough pieces enabled.");
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

        Debug.Log("Switched to Station 4 camera.");
    }
}
