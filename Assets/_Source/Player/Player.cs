using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask deathLayer;
    [SerializeField] private float standardGravityScale;
    [SerializeField] private ParticleSystem trail;

    public event Action OnDeath;
    
    private IInputHandler inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public void Prepare()
    {
        rb.gravityScale = 0;
        trail.Stop();
    }

    public void Activate()
    {
        rb.gravityScale = standardGravityScale;
        trail.Play();
    }

    private void OnEnable()
    {
        inputHandler.OnInputHold += JumpPhysics;
    }

    private void OnDisable()
    {
        inputHandler.OnInputHold -= JumpPhysics;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((deathLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            Death();
        }
    }

    private void JumpPhysics()
    {
        rb.velocity = new Vector2(0, jumpForce);
    }

    private void Death()
    {
        OnDeath?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}