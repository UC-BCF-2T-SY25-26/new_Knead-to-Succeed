using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractableObject obj = hit.collider.GetComponent<InteractableObject>();

                if (obj != null)
                {
                    obj.Interact();
                }
            }
        }
    }
}