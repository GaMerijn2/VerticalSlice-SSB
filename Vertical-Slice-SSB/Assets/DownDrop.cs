using UnityEngine;

public class DownDrop : MonoBehaviour
{
    public OneWayPlat oneWayPlat;
    public bool isColliding;
    public Collider playercol;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision other)
    {

        isColliding = true;
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && isColliding)
        {
            Physics.IgnoreCollision(oneWayPlat.platformcol, playercol, false);
            Debug.Log("Test");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
