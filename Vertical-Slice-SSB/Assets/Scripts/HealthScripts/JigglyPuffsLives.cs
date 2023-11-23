using UnityEngine;

public class JigglyPuffsLives : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    public WinScreen WinScreen;
    private void Awake()
    {
        currentLives = startingLives;
    }
    public void DecreaseLives()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            gameObject.SetActive(false);
            currentLives = 0;
            WinScreen.JigglyPuffWin();
        }

    }
}