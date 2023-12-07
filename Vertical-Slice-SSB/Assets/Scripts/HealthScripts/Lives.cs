using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    public WinScreen WinScreen; // Reference to the WinScreen script
    public bool isP1;
    public bool isP2;
    public Image[] liveimgs;

    private void Awake()
    {
        currentLives = startingLives;

    }

    public void DecreaseLives()
    {
        currentLives--;
        if (currentLives >= 0 && currentLives < liveimgs.Length)
        {
            liveimgs[currentLives].gameObject.SetActive(false);
        }

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
}
