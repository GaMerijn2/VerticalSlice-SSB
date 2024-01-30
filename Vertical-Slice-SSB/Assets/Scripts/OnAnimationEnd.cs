using System;
using UnityEngine;

public class OnAnimationEnd : MonoBehaviour
{
    public static event Action OnAniEnd;
    public static event Action OnHit;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyObj()
    {
        GameObject.Destroy(this.gameObject);
    }
    public void SignalEnd()
    {
        OnAniEnd?.Invoke();
    }
    public void SignalHit()
    {
        OnHit?.Invoke();
    }
}
