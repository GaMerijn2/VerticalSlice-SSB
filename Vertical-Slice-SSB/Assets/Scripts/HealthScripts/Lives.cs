using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    public WinScreen WinScreen;
    public bool isP1;
    public bool isP2;
    public Image[] liveimgs;
    public static UnityEvent Died = new UnityEvent();

    private void Awake()
    {
        currentLives = startingLives;

    }
    void MinusLives()
    {
        currentLives--;
    }
    public void DecreaseLives()
    {
        Died?.Invoke();
        Died.AddListener(MinusLives);


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
