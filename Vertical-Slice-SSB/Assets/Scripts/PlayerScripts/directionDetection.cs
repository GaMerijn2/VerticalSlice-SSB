using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionDetection : MonoBehaviour
{
    [SerializeField] GameObject opponent;
    public string horizontalinput;


    private void Start()
    {
      
    }

    public void Update()
    {
        Debug.Log(horizontalinput);
    }

}
