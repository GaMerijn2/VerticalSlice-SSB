using UnityEngine;

public class startbutton : MonoBehaviour
{
    public GameObject StartButton;
    public bool paused;
    // Start is called before the first frame update
    void Stop()
    {
        StartButton.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

        AudioListener.pause = true; // Pause all audio sources
    }

    public void Play()
    {
        StartButton.SetActive(false);
        Time.timeScale = 1f;
        paused = false;

        AudioListener.pause = false; // Resume all audio sources
    }
}
