using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialPanel;

    [TextArea(2,4)]
    public string[] steps;

    int currentStep = 0;

    void Start()
    {
        ShowStep();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextStep();
        }
    }

    void ShowStep()
    {
        if(currentStep < steps.Length)
        {
            tutorialText.text = steps[currentStep];
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }

    void NextStep()
    {
        currentStep++;
        ShowStep();
    }
}