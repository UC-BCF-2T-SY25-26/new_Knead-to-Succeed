using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactDistance = 5f;
    public KeyCode interactKey = KeyCode.E;

    public LayerMask interactableLayer;

    private SceneLoaderInteractable currentInteractable;

    void Update()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            SceneLoaderInteractable interactable =
                hit.collider.GetComponent<SceneLoaderInteractable>();

            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    ClearHighlight();

                    currentInteractable = interactable;
                    currentInteractable.Highlight();
                }

                if (Input.GetKeyDown(interactKey))
                {
                    SceneManager.LoadScene(interactable.sceneToLoad);
                }

                return;
            }
        }

        ClearHighlight();
    }

    void ClearHighlight()
    {
        if (currentInteractable != null)
        {
            currentInteractable.RemoveHighlight();
            currentInteractable = null;
        }
    }
}