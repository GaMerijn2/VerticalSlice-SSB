using UnityEngine;

public class Lives : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;

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
        }
        
    }
}
