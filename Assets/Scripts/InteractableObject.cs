using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    public GameObject cameraToEnable; // table camera
    public GameObject cameraToDisable; // main camera
    public GameObject player;
    public MonoBehaviour playerMovementScript;
    public TutorialManager tutorialManager;

    public GameObject[] tableIngredients; // all ingredient objects

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
            Interact();
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

    public void Interact()
    {
        if (cameraToEnable != null) cameraToEnable.SetActive(true);
        if (cameraToDisable != null) cameraToDisable.SetActive(false);

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        foreach (var ingredient in tableIngredients)
        {
            var drag = ingredient.GetComponent<DraggableIngredient>();
            if (drag != null)
                drag.canDrag = true;
        }

        if (tutorialManager != null)
            tutorialManager.NextStep();
    }

    public void ExitTable()
    {
        if (cameraToEnable != null) cameraToEnable.SetActive(false);
        if (cameraToDisable != null) cameraToDisable.SetActive(true);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        foreach (var ingredient in tableIngredients)
        {
            var drag = ingredient.GetComponent<DraggableIngredient>();
            if (drag != null)
                drag.canDrag = false;
        }
    }
}