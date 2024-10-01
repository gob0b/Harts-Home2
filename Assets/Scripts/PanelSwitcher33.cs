using System.Collections;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    // Array of panels to switch between
    public GameObject[] panels;

    // Delay in seconds between switching panels
    public float switchDelay = 2f;

    // Private variable to track the current panel index
    private int currentPanelIndex = 0;

    void Start()
    {
        // Ensure only the first panel is active at the start
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == 0); // Activate the first panel, deactivate others
        }

        // Start the coroutine to switch panels
        StartCoroutine(SwitchPanels());
    }

    // Coroutine to handle panel switching with a delay
    IEnumerator SwitchPanels()
    {
        while (true) // Loop indefinitely
        {
            // Wait for the specified delay before switching to the next panel
            yield return new WaitForSeconds(switchDelay);

            // Deactivate the current panel
            panels[currentPanelIndex].SetActive(false);

            // Move to the next panel, loop back if at the last panel
            currentPanelIndex = (currentPanelIndex + 1) % panels.Length;

            // Activate the next panel
            panels[currentPanelIndex].SetActive(true);
        }
    }
}
