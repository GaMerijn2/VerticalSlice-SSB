using TMPro;
using UnityEngine;

public class KirbysLives : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    public WinScreen WinScreen;
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        currentLives = startingLives;
        livesText.text = startingLives.ToString() + " lives left";

    }
    public void DecreaseLives()
    {
        currentLives--;
        livesText.text = currentLives.ToString() + " lives left";

        if (currentLives <= 0)
        {
            gameObject.SetActive(false);
            currentLives = 0;
            WinScreen.Kirbywin();
        }

    }
}
