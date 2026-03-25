using UnityEngine;
using UnityEngine.UI;

public class IntroChatBubble : MonoBehaviour
{
    public GameObject chatBubblePanel;
    public Image chatBubbleImage;
    public Sprite[] bubbleSprites;

    private int currentMessage = 0;
    private bool introActive = true;

    private void Start()
    {
        if (chatBubblePanel != null)
        {
            chatBubblePanel.SetActive(true);
        }

        ShowMessage();
    }

    private void Update()
    {
        if (!introActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            currentMessage++;

            if (currentMessage < bubbleSprites.Length)
            {
                ShowMessage();
            }
            else
            {
                EndIntro();
            }
        }
    }

    private void ShowMessage()
    {
        if (chatBubbleImage != null && currentMessage < bubbleSprites.Length)
        {
            chatBubbleImage.sprite = bubbleSprites[currentMessage];
            chatBubbleImage.enabled = true;
        }
    }

    private void EndIntro()
    {
        introActive = false;

        if (chatBubbleImage != null)
        {
            chatBubbleImage.enabled = false;
        }

        if (chatBubblePanel != null)
        {
            chatBubblePanel.SetActive(false);
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.ShowCurrentStep();
        }

        Debug.Log("Intro chat finished.");
    }
}
