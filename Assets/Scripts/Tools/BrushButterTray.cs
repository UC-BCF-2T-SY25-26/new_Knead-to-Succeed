using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BrushButterTray : MonoBehaviour
{
    [Header("Tray Swap")]
    public GameObject trayObject;
    public GameObject butteredTrayObject;

    [Header("Optional")]
    public bool hideBrushAfterUse = false;

    private bool hasBrushed = false;

    private void Start()
    {
        if (butteredTrayObject != null)
        {
            butteredTrayObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (hasBrushed) return;

        if (trayObject == null)
        {
            Debug.LogWarning("No trayObject assigned.");
            return;
        }

        if (butteredTrayObject == null)
        {
            Debug.LogWarning("No butteredTrayObject assigned.");
            return;
        }

        hasBrushed = true;

        trayObject.SetActive(false);
        butteredTrayObject.SetActive(true);

        Debug.Log("Tray has been buttered.");

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        if (hideBrushAfterUse)
        {
            gameObject.SetActive(false);
        }
    }
}
