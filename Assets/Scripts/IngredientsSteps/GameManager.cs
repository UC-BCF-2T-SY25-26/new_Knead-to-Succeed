using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentStep = 0; // first ingredient
    public int requiredCount = 1; // how many ingredients needed for this step
    private int currentCount = 0;

    public void IngredientAdded()
    {
        currentCount++;
        if (currentCount >= requiredCount)
        {
            currentStep++;
            currentCount = 0;
            Debug.Log("Moved to step: " + currentStep);
        }
    }
}