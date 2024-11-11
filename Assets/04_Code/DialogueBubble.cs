using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; // Requires DOTween for animations

public class DialogueBubble : MonoBehaviour
{
    public Text dialogueText;
    public float animationDuration = 0.3f;

    public void SetText(string text)
    {
        dialogueText.text = text;
    }

    public void AnimateBubble()
    {
        RectTransform rect = GetComponent<RectTransform>();

        // Animate the bubble's entrance
        rect.localScale = Vector3.zero;
        rect.DOScale(Vector3.one, animationDuration).SetEase(Ease.OutBack);

        // Optional: You can also add a fading effect or delay
    }
}
