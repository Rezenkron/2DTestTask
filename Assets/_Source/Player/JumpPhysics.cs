using UnityEngine;

public class JumpPhysics
{
    public void DoJump(Rigidbody2D rb, float input, float jumpForce)
    {
        if(input > 0)
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
    }
}
