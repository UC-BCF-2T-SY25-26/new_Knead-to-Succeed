using UnityEngine;
using UnityEngine.EventSystems;

public class BowlDropZone : MonoBehaviour, IDropHandler
{
    public GameManager gameManager;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableIngredient ingredient = eventData.pointerDrag.GetComponent<DraggableIngredient>();
        IngredientStep step = eventData.pointerDrag.GetComponent<IngredientStep>();

        if (ingredient != null && step != null)
        {
            if (step.stepNumber == gameManager.currentStep)
            {
                Debug.Log("Correct ingredient added!");
                ingredient.transform.position = transform.position; // snap
                ingredient.enabled = false; // stop dragging
                gameManager.IngredientAdded();
            }
            else
            {
                Debug.Log("Wrong step! Resetting ingredient.");
                ingredient.ResetPosition();
            }
        }
    }
}