using UnityEngine;
using System.Collections;

public class PanelSwitcherWithDelay2 : MonoBehaviour
{
    // Array of panels to switch between
    public GameObject[] panels;

    // Delay in seconds between switching panels
    public float switchDelay = 2f;

    // Private variable to track the current panel index
    private int currentIndex = 0;

    void Start()
    {
        // Make sure all panels except the first one are inactive
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == 0); // Only activate the first panel
        }

        // Start the coroutine to switch panels after delay
        StartCoroutine(SwitchPanels());
    }

    // Coroutine to switch panels with a delay
    IEnumerator SwitchPanels()
    {
        while (true) // Loop infinitely
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(switchDelay);

            // Deactivate the current panel
            panels[currentIndex].SetActive(false);

            // Move to the next panel
            currentIndex = (currentIndex + 1) % panels.Length;

            // Activate the next panel
            panels[currentIndex].SetActive(true);
        }
    }
}