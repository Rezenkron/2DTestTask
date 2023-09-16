using UnityEngine;

public class Player : APlayer
{
    private bool isInputActive;

    public override void Prepare()
    {
        rb.gravityScale = 0;
        trail.Stop();
    }

    public override void Activate()
    {
        rb.gravityScale = standardGravityScale;
        trail.Play();
    }

    private void OnEnable()
    {
        inputHandler.OnInputHold += DoJump;
    }

    private void OnDisable()
    {
        inputHandler.OnInputHold -= DoJump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((deathLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            Death();
        }
    }

    private void Update()
    {
        if(isInputActive)
        {
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime);
        }
    }

    private void DoJump(bool active)
    {
        isInputActive = active;
    }
}