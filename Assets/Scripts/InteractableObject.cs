using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Color highlightColor = Color.yellow;

    public GameObject cameraToEnable;
    public GameObject cameraToDisable;

    public TutorialManager tutorialManager;

    private Renderer objectRenderer;
    private Color originalColor;

    private bool playerLooking = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
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
        objectRenderer.material.color = highlightColor;
    }

    public void OnRaycastExit()
    {
        playerLooking = false;
        objectRenderer.material.color = originalColor;
    }

    void Interact()
    {
        // Switch cameras
        if (cameraToEnable != null)
            cameraToEnable.SetActive(true);

        if (cameraToDisable != null)
            cameraToDisable.SetActive(false);

        // Advance tutorial instruction
        if (tutorialManager != null)
            tutorialManager.NextStep();
    }
}