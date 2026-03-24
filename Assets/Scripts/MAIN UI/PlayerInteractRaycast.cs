using UnityEngine;

public class PlayerInteractRaycast : MonoBehaviour
{
    public float interactDistance = 8f;
    public LayerMask interactableLayer;

    private TableInteractable currentInteractable;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            TableInteractable interactable = hit.collider.GetComponentInParent<TableInteractable>();

            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    ClearCurrentInteractable();
                    currentInteractable = interactable;
                    currentInteractable.OnRaycastHit();
                }

                if (Input.GetKeyDown(KeyCode.E))
                    currentInteractable.Interact();

                return;
            }
        }

        ClearCurrentInteractable();
    }

    void ClearCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable.OnRaycastExit();
            currentInteractable = null;
        }
    }
}