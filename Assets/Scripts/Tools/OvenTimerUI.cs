using UnityEngine;
using TMPro;

public class OvenTimerUI : MonoBehaviour
{
    [Header("Oven Settings")]
    public Transform traySnapPoint;

    [Header("Timer Settings")]
    public float bakeDuration = 5f;

    [Header("UI")]
    public TMP_Text timerText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip ovenRunningSfx;

    public bool IsBakeComplete { get; private set; }

    private float timeRemaining;
    private bool timerRunning = false;

    private void Awake()
    {
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        timeRemaining = bakeDuration;
        IsBakeComplete = false;
    }

    private void Update()
    {
        if (!timerRunning) return;

        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                timerRunning = false;
                IsBakeComplete = true;
                UpdateFinishedDisplay();

                if (audioSource != null)
                {
                    audioSource.Stop();
                }

                if (TutorialManager.Instance != null)
                {
                    TutorialManager.Instance.NextStep();
                }

                Debug.Log("Oven finished baking!");
                return;
            }

            UpdateTimerDisplay(timeRemaining);
        }
    }

    public void StartOvenTimer()
    {
        if (timerRunning) return;

        timeRemaining = bakeDuration;
        timerRunning = true;
        IsBakeComplete = false;

        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
        }

        if (audioSource != null && ovenRunningSfx != null)
        {
            audioSource.clip = ovenRunningSfx;
            audioSource.loop = false;
            audioSource.Play();
        }

        UpdateTimerDisplay(timeRemaining);
        Debug.Log("Oven timer started.");
    }

    public void HideTimerUI()
    {
        timerRunning = false;

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }
    }

    public Transform GetTraySnapTarget()
    {
        return traySnapPoint != null ? traySnapPoint : transform;
    }

    private void UpdateTimerDisplay(float time)
    {
        if (timerText == null) return;

        int totalSeconds = Mathf.CeilToInt(time);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpdateFinishedDisplay()
    {
        if (timerText == null) return;
        timerText.text = "Done!";
    }
}
