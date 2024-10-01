using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    // The AudioSource component that will play the sound
    public AudioSource audioSource;

    // The AudioClip to be played
    public AudioClip buttonSound;

    // Reference to the button component
    public Button button;

    void Start()
    {
        // Ensure we have an AudioSource and Button attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the AudioClip to the AudioSource
        audioSource.clip = buttonSound;

        // Add a listener to the button that triggers the PlaySound method when clicked
        button.onClick.AddListener(PlaySound);
    }

    // Method to play the sound when the button is pressed
    public void PlaySound()
    {
        if (audioSource != null && buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }
}