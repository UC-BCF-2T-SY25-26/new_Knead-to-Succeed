using UnityEngine;

public class Station2Cam : MonoBehaviour
{
    [Header("Camera Switch")]
    public GameObject currentCamera;
    public GameObject station2Camera;

    [Header("Station 1 Bowl")]
    public BowlDropZone bowlDropZone;

    [Header("Dough")]
    public GameObject doughObject;

    [Header("Debug")]
    public bool enableDebugSkip = true;
    public KeyCode debugJumpKey = KeyCode.Return;

    private void Update()
    {
        if (enableDebugSkip && Input.GetKeyDown(debugJumpKey))
        {
            SwitchToStation2();
            Debug.Log("Debug skip: jumped straight to Station 2.");
        }
    }

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

        if (bowlDropZone != null)
        {
            bowlDropZone.enabled = false;
            Debug.Log("BowlDropZone disabled for Station 2.");
        }

        if (doughObject != null)
        {
            doughObject.SetActive(true);
            Debug.Log("Dough enabled: " + doughObject.name);
        }
        else
        {
            Debug.LogWarning("No doughObject assigned on Station2Cam.");
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        gameObject.SetActive(false);

        Debug.Log("Switched to Station 2 camera.");
    }
}
