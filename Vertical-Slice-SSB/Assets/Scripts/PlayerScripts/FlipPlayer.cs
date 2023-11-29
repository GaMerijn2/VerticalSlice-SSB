using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    [SerializeField] private bool isFacingRight;
    [SerializeField] private string flipAxis;
    void Start()
    {
        isFacingRight = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis(flipAxis);

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


