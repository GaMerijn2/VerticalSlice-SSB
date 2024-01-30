using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    void Update()
    {
        Invoke(nameof(DestroyObject), destroyTime);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
