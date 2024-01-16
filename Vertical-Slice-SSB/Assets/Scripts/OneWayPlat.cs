using UnityEngine;

public class OneWayPlat : MonoBehaviour
{
    public bool isOneWay = true;
    public GameObject player;
    public GameObject player2;
    public Collider platformcol;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        platformcol = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isOneWay && (other.gameObject == player || other.gameObject == player2))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            if (rb.velocity.y > 0)
            {
                Physics.IgnoreCollision(platformcol, other, true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isOneWay && (other.gameObject == player || other.gameObject == player2))
        {
            Physics.IgnoreCollision(platformcol, other, false);
        }
    }
}
