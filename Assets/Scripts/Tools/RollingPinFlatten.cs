using UnityEngine;

public class RollingPinFlatten : MonoBehaviour
{
    [Header("Dough Swap")]
    public GameObject doughObject;
    public GameObject flattenedDoughObject;

    [Header("Optional")]
    public bool hideRollingPinAfterUse = false;

    private bool hasRolled = false;

    private void OnMouseDown()
    {
        if (hasRolled) return;

        if (doughObject == null)
        {
            Debug.LogWarning("No doughObject assigned.");
            return;
        }

        if (flattenedDoughObject == null)
        {
            Debug.LogWarning("No flattenedDoughObject assigned.");
            return;
        }

        hasRolled = true;

        flattenedDoughObject.transform.position = doughObject.transform.position;
        flattenedDoughObject.transform.rotation = doughObject.transform.rotation;
        flattenedDoughObject.transform.localScale = doughObject.transform.localScale;

        flattenedDoughObject.SetActive(true);
        doughObject.SetActive(false);

        Debug.Log("Dough flattened.");

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        if (hideRollingPinAfterUse)
        {
            gameObject.SetActive(false);
        }
    }
}
