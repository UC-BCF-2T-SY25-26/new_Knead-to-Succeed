using UnityEngine;
using TMPro;

public class InstructionSequence : MonoBehaviour
{
    public TextMeshProUGUI instructionText; // UI text element
    public GameObject instructionPanel; // panel background (optional)

    public string[] instructions; // list of instructions
    private int currentInstruction = 0;

    void Start()
    {
        ShowInstruction();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextInstruction();
        }
    }

    void ShowInstruction()
    {
        if (currentInstruction < instructions.Length)
        {
            instructionPanel.SetActive(true);
            instructionText.text = instructions[currentInstruction];
        }
        else
        {
            instructionPanel.SetActive(false); // hide when finished
        }
    }

    void NextInstruction()
    {
        currentInstruction++;
        ShowInstruction();
    }
}