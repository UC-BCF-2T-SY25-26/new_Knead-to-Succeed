using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SnapToMixer : MonoBehaviour
{
    [Header("Snap Settings")]
    public string mixerTag = "Mixer";
    public bool disableAfterSnap = true;
    public bool parentToMixerAfterSnap = true;
    public bool keepCurrentRotationOnSnap = true;
    public Vector3 snapRotationEuler = Vector3.zero;
    public bool useCustomRotation = false;

    private bool hasSnapped = false;

    private void OnTriggerEnter(Collider other)
    {
        TrySnap(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TrySnap(collision.collider);
    }

    private void TrySnap(Collider other)
    {
        if (hasSnapped) return;
        if (!other.CompareTag(mixerTag)) return;

        MixerTimerUI mixerTimer = other.GetComponent<MixerTimerUI>();
        if (mixerTimer == null)
        {
            Debug.LogWarning("Snap failed because MixerTimerUI is missing on " + other.name);
            return;
        }

        Transform target = mixerTimer.GetSnapTarget();

        transform.position = target.position;

        if (useCustomRotation)
        {
            transform.rotation = Quaternion.Euler(snapRotationEuler);
        }
        else if (!keepCurrentRotationOnSnap)
        {
            transform.rotation = target.rotation;
        }

        if (parentToMixerAfterSnap)
        {
            transform.SetParent(other.transform, true);
        }

        hasSnapped = true;

        Debug.Log(gameObject.name + " has snapped to the mixer.");

        mixerTimer.StartMixerTimer();

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.NextStep();
        }

        if (disableAfterSnap)
        {
            Collider myCollider = GetComponent<Collider>();
            if (myCollider != null)
            {
                myCollider.enabled = false;
            }

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
