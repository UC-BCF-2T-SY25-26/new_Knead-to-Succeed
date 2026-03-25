using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OvenTakeOutBread : MonoBehaviour
{
    [Header("References")]
    public OvenTimerUI ovenTimerUI;
    public GameObject bakedTrayObject;
    public GameObject finishedBreadObject;
    public GameObject nextArrowButton;

    [Header("Optional")]
    public bool hideTimerWhenTakenOut = true;

    private bool hasCollected = false;

    private void Awake()
    {
        if (bakedTrayObject != null)
        {
            bakedTrayObject.SetActive(false);
        }

        if (finishedBreadObject != null)
        {
            finishedBreadObject.SetActive(false);
        }

        if (nextArrowButton != null)
        {
            nextArrowButton.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (hasCollected) return;

        if (ovenTimerUI == null)
        {
            Debug.LogWarning("No OvenTimerUI assigned.");
            return;
        }

        if (!ovenTimerUI.IsBakeComplete)
        {
            Debug.Log("Oven clicked, but baking is not finished yet.");
            return;
        }

        hasCollected = true;

        if (bakedTrayObject != null)
        {
            bakedTrayObject.SetActive(true);
        }

        if (finishedBreadObject != null)
        {
            finishedBreadObject.SetActive(true);
        }

        if (nextArrowButton != null)
        {
            nextArrowButton.SetActive(true);
        }

        if (hideTimerWhenTakenOut)
        {
            ovenTimerUI.HideTimerUI();
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        Debug.Log("Baked tray and bread revealed.");
    }
}
