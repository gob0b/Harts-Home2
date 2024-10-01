using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // The Text component to scale
    public Text targetText;

    // Normal and enlarged scales
    public float normalScale = 1f;
    public float enlargedScale = 1.2f;

    // Speed of the scale transition
    public float scaleSpeed = 5f;

    // Private variable to store the current target scale
    private float targetScale;

    void Start()
    {
        // Initialize the target scale to normal
        targetScale = normalScale;

        // If targetText is not assigned, get the Text component attached to the same GameObject
        if (targetText == null)
        {
            targetText = GetComponent<Text>();
        }

        // Set the initial scale to normal
        targetText.transform.localScale = Vector3.one * normalScale;
    }

    void Update()
    {
        // Smoothly scale the text towards the target scale
        if (targetText.transform.localScale != Vector3.one * targetScale)
        {
            targetText.transform.localScale = Vector3.Lerp(targetText.transform.localScale, Vector3.one * targetScale, Time.deltaTime * scaleSpeed);
        }
    }

    // Called when the mouse enters the text area
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Set the target scale to the enlarged scale
        targetScale = enlargedScale;
    }

    // Called when the mouse exits the text area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Set the target scale back to normal
        targetScale = normalScale;
    }
}