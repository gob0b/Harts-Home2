using UnityEngine;
using UnityEngine.UI;

public class GlitchyMetronome : MonoBehaviour
{
    // The Image component to rotate
    public Image targetImage;

    // Adjustable parameters
    public float rockAngle = 30f;        // Max angle to rock in each direction
    public float rockSpeed = 2f;         // Speed of rocking (oscillation)
    public float glitchFrequency = 0.3f; // How often glitches happen
    public float maxGlitchAngle = 15f;   // Maximum deviation during glitches

    // Private variables
    private RectTransform rectTransform;
    private float time;
    private float nextGlitchTime;
    private bool isGlitching = false;

    void Start()
    {
        // Get the RectTransform of the target image
        if (targetImage != null)
        {
            rectTransform = targetImage.GetComponent<RectTransform>();
        }
        else
        {
            rectTransform = GetComponent<RectTransform>();
        }

        // Set the first glitch event
        ScheduleNextGlitch();
    }

    void Update()
    {
        // Handle rocking motion
        if (!isGlitching)
        {
            PerformRockingMotion();
        }

        // Handle glitches
        if (Time.time >= nextGlitchTime)
        {
            GlitchRotation();
            ScheduleNextGlitch();
        }
    }

    // Function to apply the rocking motion like a metronome
    void PerformRockingMotion()
    {
        // Sinusoidal rocking between -rockAngle and +rockAngle
        time += Time.deltaTime * rockSpeed;
        float angle = Mathf.Sin(time) * rockAngle;
        rectTransform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    // Apply a random glitch rotation
    void GlitchRotation()
    {
        isGlitching = true;

        // Apply random glitch angle in a random direction
        float randomAngle = Random.Range(-maxGlitchAngle, maxGlitchAngle);
        rectTransform.localRotation = Quaternion.Euler(0, 0, randomAngle);

        // Restore rocking after a short glitch
        Invoke("EndGlitch", 0.1f); // Glitch lasts for 0.1 seconds
    }

    // Ends the glitch and resumes the rocking motion
    void EndGlitch()
    {
        isGlitching = false;
    }

    // Schedule the next glitch event
    void ScheduleNextGlitch()
    {
        nextGlitchTime = Time.time + Random.Range(glitchFrequency * 0.8f, glitchFrequency * 1.2f);
    }
}
