using UnityEngine;

public class PlayerInteractRaycast : MonoBehaviour
{
    public float interactDistance = 8f;

    public LayerMask interactableLayer;

    private InteractableObject currentInteractable;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            Debug.Log("Ray hit: " + hit.collider.name);

            InteractableObject interactable = hit.collider.GetComponentInParent<InteractableObject>();

            if (interactable != null)
            {
                if (currentInteractable != interactable)
                {
                    ClearCurrentInteractable();

                    currentInteractable = interactable;
                    currentInteractable.OnRaycastHit();
                }

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