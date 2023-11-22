using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockbackScript : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Knockback(Vector3 direction)
    {
        rb.AddForce(direction, ForceMode.VelocityChange);
    }


}
