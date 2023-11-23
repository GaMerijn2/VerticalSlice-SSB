using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] public GameObject KirbyWinUI;
    [SerializeField] public GameObject jigglypuffWinUI;
    // Start is called before the first frame update
    public void Kirbywin()
    {
        KirbyWinUI.SetActive(true);
    }
    public void JigglyPuffWin() 
    {
    jigglypuffWinUI.SetActive(true);
    }
}