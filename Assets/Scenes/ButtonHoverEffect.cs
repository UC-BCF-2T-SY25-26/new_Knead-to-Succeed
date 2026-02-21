using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.Play("ButtonHover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.Play("ButtonIdle");
    }
}