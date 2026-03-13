using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Camera mainCamera;
    public Camera interactionCamera;

    public void Interact()
    {
        mainCamera.enabled = false;
        interactionCamera.enabled = true;
    }
}