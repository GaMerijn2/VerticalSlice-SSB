using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public RandomAudioClip randomAudioClip;

    // Example method to play a random audio clip
    public void PlayRandomAudio()
    {
        // Get a random audio clip using the RandomAudioClip script
        AudioClip randomClip = randomAudioClip.GetRandomAudioClip();

        // Check if a valid audio clip was returned
        if (randomClip != null)
        {
            // Play the audio clip
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                // If there is no AudioSource component on this GameObject, add one
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}
