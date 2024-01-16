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
    public PlayerHealth HealthReset;

    private void Awake()
    {
        currentLives = startingLives;

    }

    public void DecreaseLives()
    {
        currentLives--;
        HealthReset.damage = 0f;

        if (currentLives >= 0 && currentLives < liveimgs.Length)
        {
            liveimgs[currentLives].gameObject.SetActive(false);
        }

        if (currentLives <= 0)
        {
            if (isP1)
            {
                KirbyWin();
            }
            else if (isP2)
            {
                JigglypuffWin();
            }

            gameObject.SetActive(false);
            currentLives = 0;

        }
    }
    public void KirbyWin()
    {
        WinScreen.Kirbywin();
        Time.timeScale = 0f;

    }
    public void JigglypuffWin()
    {
        WinScreen.JigglyPuffWin();
        Time.timeScale = 0f;
    }
}
