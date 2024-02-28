using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public abstract class APlayer : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float standardGravityScale;
    [SerializeField] protected LayerMask deathLayer;
    [SerializeField] protected ParticleSystem trail;

    protected IInputHandler inputHandler;

    [Inject]
    private void Construct(IInputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public event Action OnDeath;

    public abstract void Prepare();

    public abstract void Activate();

    protected virtual void Death()
    {
        OnDeath?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}