using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TrayIntoOven : MonoBehaviour
{
    [Header("Oven Settings")]
    public string ovenTag = "Oven";

    private bool hasPlaced = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlaced) return;
        if (!other.CompareTag(ovenTag)) return;

        hasPlaced = true;

        DragPlaneFix dragScript = GetComponent<DragPlaneFix>();
        if (dragScript != null)
        {
            dragScript.enabled = false;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        OvenTimerUI ovenTimer = other.GetComponent<OvenTimerUI>();
        if (ovenTimer != null)
        {
            ovenTimer.StartOvenTimer();
        }
        else
        {
            Debug.LogWarning("No OvenTimerUI found on " + other.name);
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        gameObject.SetActive(false);

        Debug.Log("Tray entered oven zone and disappeared.");
    }
}
