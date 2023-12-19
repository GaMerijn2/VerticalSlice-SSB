using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    public WinScreen WinScreen; // Reference to the WinScreen script
    public TextMeshProUGUI livesText;
    public bool isP1;
    public bool isP2;

    private void Awake()
    {
        currentLives = startingLives;
        UpdateLivesText();
    }

    public void DecreaseLives()
    {
        currentLives--;
        UpdateLivesText();

        if (currentLives <= 0)
        {
            if (isP1)
            {
                WinScreen.Kirbywin();
            }
            else if (isP2)
            {
                WinScreen.JigglyPuffWin();
            }

            gameObject.SetActive(false);
            currentLives = 0;
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = currentLives.ToString() + " lives left";
    }
}
