using UnityEngine;
using TMPro;

public class MixerTimerUI : MonoBehaviour
{
    [Header("Snap Settings")]
    public Transform snapPoint;

    [Header("Timer Settings")]
    public float mixDuration = 5f;

    [Header("UI")]
    public TMP_Text timerText;
    public string finishedText = "00:00";
    public GameObject nextStationArrowButton;

    private float timeRemaining;
    private bool timerRunning = false;

    private void Start()
    {
        timeRemaining = mixDuration;

        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }

        if (nextStationArrowButton != null)
        {
            nextStationArrowButton.SetActive(false);
        }
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
                UpdateFinishedDisplay();

                if (nextStationArrowButton != null)
                {
                    nextStationArrowButton.SetActive(true);
                }

                if (TutorialManager.Instance != null)
                {
                    TutorialManager.Instance.NextStep();
                }

                Debug.Log("Mixer finished!");
                return;
            }

            UpdateTimerDisplay(timeRemaining);
        }
    }

    public void StartMixerTimer()
    {
        if (timerRunning) return;

        timeRemaining = mixDuration;
        timerRunning = true;

        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
        }

        if (nextStationArrowButton != null)
        {
            nextStationArrowButton.SetActive(false);
        }

        UpdateTimerDisplay(timeRemaining);

        Debug.Log("Mixer timer started.");
    }

    public Transform GetSnapTarget()
    {
        return snapPoint != null ? snapPoint : transform;
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
        timerText.text = finishedText;
    }
}
