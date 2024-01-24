using System;
using UnityEngine;

public class OnAnimationEnd : MonoBehaviour
{
    public static event Action OnAniEnd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SignalEnd()
    {
        OnAniEnd?.Invoke();
    }
}
