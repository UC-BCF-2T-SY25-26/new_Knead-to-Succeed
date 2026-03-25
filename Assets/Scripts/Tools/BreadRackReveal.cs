using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BreadRackReveal : MonoBehaviour
{
    [Header("Bread Display")]
    public GameObject pandesalGroupObject;

    [Header("Next Arrow")]
    public GameObject nextArrowButton;

    [Header("Optional")]
    public bool hideRackAfterUse = false;

    private bool hasRevealed = false;

    private void Awake()
    {
        if (pandesalGroupObject != null)
        {
            pandesalGroupObject.SetActive(false);
        }

        if (nextArrowButton != null)
        {
            nextArrowButton.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (hasRevealed) return;

        if (pandesalGroupObject == null)
        {
            Debug.LogWarning("No pandesalGroupObject assigned.");
            return;
        }

        hasRevealed = true;

        pandesalGroupObject.SetActive(true);

        if (nextArrowButton != null)
        {
            nextArrowButton.SetActive(true);
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        if (hideRackAfterUse)
        {
            gameObject.SetActive(false);
        }

        Debug.Log("Pandesal group revealed.");
    }
}
