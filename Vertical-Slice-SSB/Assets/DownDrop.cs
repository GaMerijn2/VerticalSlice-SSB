using UnityEngine;

public class DownDrop : MonoBehaviour
{
    public bool isColliding;
    public Collider playercol;
    [SerializeField] private Collider platTouch;
    [SerializeField] private int wichPlayer;
    [SerializeField] private KeyCode key;

    void Start()
    {
        if (wichPlayer == 2)
        {
            key = KeyCode.DownArrow;
        }

        if (wichPlayer == 1)
        {
            key = KeyCode.S;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlat"))
        {
            platTouch = collision.collider;
            isColliding = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(key) && isColliding)
        {
            Physics.IgnoreCollision(platTouch, playercol, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlat"))
        {
            isColliding = false;
        }
    }
}
