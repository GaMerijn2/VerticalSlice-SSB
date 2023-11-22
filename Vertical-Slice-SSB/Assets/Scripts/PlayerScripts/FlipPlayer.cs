using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isFacingRight;
    void Start()
    {
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

                   // Flip the player if moving in the opposite direction
        if ((horizontalInput < 0 && !isFacingRight) || (horizontalInput > 0 && isFacingRight))
        {
            // Flip the scale of the player along the x-axis
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            // Update the facing direction
            isFacingRight = !isFacingRight;
        }
    }
}
