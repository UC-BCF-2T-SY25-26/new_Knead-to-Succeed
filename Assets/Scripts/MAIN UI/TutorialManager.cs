using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public TextMeshProUGUI tutorialText;
    public GameObject tutorialPanel;

    [TextArea(2, 4)]
    public string[] steps;

    int currentStep = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShowStep();
    }

    void ShowStep()
    {
        if (currentStep < steps.Length)
        {
            tutorialText.text = steps[currentStep];
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }

    public void NextStep()
    {
        currentStep++;
        ShowStep();
    }
}
