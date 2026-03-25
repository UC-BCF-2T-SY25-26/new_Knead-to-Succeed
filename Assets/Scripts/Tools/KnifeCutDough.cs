using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KnifeCutDough : MonoBehaviour
{
    [Header("Dough Stages")]
    public GameObject flattenedDoughObject;
    public GameObject cutStage1Object;
    public GameObject cutStage2Object;
    public GameObject cutStage3Object;

    [Header("UI")]
    public GameObject nextStationArrowButton;

    [Header("Optional")]
    public bool hideKnifeAfterFinalCut = false;

    private int cutCount = 0;

    private void Start()
    {
        if (cutStage1Object != null) cutStage1Object.SetActive(false);
        if (cutStage2Object != null) cutStage2Object.SetActive(false);
        if (cutStage3Object != null) cutStage3Object.SetActive(false);

        if (nextStationArrowButton != null)
        {
            nextStationArrowButton.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Knife clicked.");

        if (cutCount == 0)
        {
            if (flattenedDoughObject == null || !flattenedDoughObject.activeInHierarchy)
            {
                Debug.Log("Knife ignored because flattened dough is not active yet.");
                return;
            }

            if (cutStage1Object == null)
            {
                Debug.LogWarning("cutStage1Object is not assigned.");
                return;
            }

            flattenedDoughObject.SetActive(false);
            cutStage1Object.SetActive(true);
            cutCount = 1;

            Debug.Log("Dough cut: stage 1");
        }
        else if (cutCount == 1)
        {
            if (cutStage1Object == null || cutStage2Object == null)
            {
                Debug.LogWarning("cutStage1Object or cutStage2Object is not assigned.");
                return;
            }

            cutStage1Object.SetActive(false);
            cutStage2Object.SetActive(true);
            cutCount = 2;

            Debug.Log("Dough cut: stage 2");
        }
        else if (cutCount == 2)
        {
            if (cutStage2Object == null || cutStage3Object == null)
            {
                Debug.LogWarning("cutStage2Object or cutStage3Object is not assigned.");
                return;
            }

            cutStage2Object.SetActive(false);
            cutStage3Object.SetActive(true);
            cutCount = 3;

            if (nextStationArrowButton != null)
            {
                nextStationArrowButton.SetActive(true);
            }

            Debug.Log("Dough cut: stage 3 / 6 pieces");

            if (TutorialManager.Instance != null)
            {
                TutorialManager.Instance.NextStep();
            }

            if (hideKnifeAfterFinalCut)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
