using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlaceCutDoughOnTray : MonoBehaviour
{
    [Header("Dough Swap")]
    public GameObject cutDoughObject;
    public GameObject trayDoughPiecesObject;

    [Header("Next Arrow")]
    public GameObject nextArrowButton;

    [Header("Optional")]
    public bool hideClickedObjectAfterUse = false;

    private bool hasPlaced = false;

    private void Awake()
    {
        if (trayDoughPiecesObject != null)
        {
            trayDoughPiecesObject.SetActive(false);
        }

        if (nextArrowButton != null)
        {
            nextArrowButton.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (hasPlaced) return;

        if (cutDoughObject == null)
        {
            Debug.LogWarning("No cutDoughObject assigned.");
            return;
        }

        if (trayDoughPiecesObject == null)
        {
            Debug.LogWarning("No trayDoughPiecesObject assigned.");
            return;
        }

        hasPlaced = true;

        cutDoughObject.SetActive(false);
        trayDoughPiecesObject.SetActive(true);

        if (nextArrowButton != null)
        {
            nextArrowButton.SetActive(true);
        }

        Debug.Log("Cut dough placed onto tray.");

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        if (hideClickedObjectAfterUse)
        {
            gameObject.SetActive(false);
        }
    }
}
