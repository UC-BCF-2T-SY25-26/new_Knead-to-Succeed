using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float rayDistance = 10f;
    public TextMeshProUGUI interactText;

    void Update()
    {
        HandleMovement();
        HandleRaycast();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, 0, moveZ) * 5f * Time.deltaTime);
    }

    void HandleRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                interactText.gameObject.SetActive(true);
                return;
            }
        }

        interactText.gameObject.SetActive(false);
    }
}