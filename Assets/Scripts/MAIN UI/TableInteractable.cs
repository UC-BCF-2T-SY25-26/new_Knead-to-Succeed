using UnityEngine;

public class TableInteractable : MonoBehaviour
{
    public Color highlightColor = Color.yellow;

    public GameObject cameraToEnable;
    public GameObject cameraToDisable;
    public MonoBehaviour playerMovementScript;

    private Renderer objectRenderer;
    private Color originalColor;
    private bool playerLooking = false;
    private bool isActive = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
            originalColor = objectRenderer.material.color;
    }

    void Update()
    {
        if (playerLooking && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void OnRaycastHit()
    {
        playerLooking = true;

        if (objectRenderer != null)
            objectRenderer.material.color = highlightColor;
    }

    public void OnRaycastExit()
    {
        playerLooking = false;

        if (objectRenderer != null)
            objectRenderer.material.color = originalColor;
    }

    public void Interact()
    {
        isActive = true;

        if (cameraToEnable != null)
            cameraToEnable.SetActive(true);

        if (cameraToDisable != null)
            cameraToDisable.SetActive(false);

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        Debug.Log("[TABLE] Interacted - camera switched ON");
    }

    public void ExitTable()
    {
        isActive = false;

        if (cameraToEnable != null)
            cameraToEnable.SetActive(false);

        if (cameraToDisable != null)
            cameraToDisable.SetActive(true);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        Debug.Log("[TABLE] Exit - camera switched OFF");
    }
}
