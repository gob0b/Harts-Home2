using UnityEngine;

public class ShowPanelAfterTime : MonoBehaviour
{
    // The panel to be shown
    public GameObject panel;

    // Time in seconds before the panel is shown
    public float delayTime = 5f;

    // Private timer variable
    private float timer = 0f;
    private bool panelShown = false;

    void Start()
    {
        // Ensure the panel is hidden initially
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // If the panel is already shown, do nothing
        if (panelShown) return;

        // Increment the timer
        timer += Time.deltaTime;

        // If the timer exceeds the delay time, show the panel
        if (timer >= delayTime)
        {
            ShowPanel();
        }
    }

    // Function to show the panel
    void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true); // Show the panel
            panelShown = true;     // Set flag so it doesn't keep running
        }
    }
}
