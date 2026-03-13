using UnityEngine;
using TMPro;

public class TutorialInstructions : MonoBehaviour
{
    public TMP_Text instructionText;

    bool hasMoved = false;

    void Update()
    {
        if (!hasMoved &&
           (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D)))
        {
            hasMoved = true;
            instructionText.text = "Great! Now navigate to the first workstation and press E to interact with it.";
        }
    }
}