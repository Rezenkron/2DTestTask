using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private string deathTag;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float jumpForce;

    private const string JUMP_BUTTON = "Jump";
    private const string ALT_JUMP_BUTTON = "Fire1";

    private float jumpInput;

    private IInputHandler input;
    private JumpPhysics jumpPhysics;

    public event Action OnDeath;

    [Inject]
    private void Construct(IInputHandler input, JumpPhysics jumpPhysics)
    {
        this.input = input;
        this.jumpPhysics = jumpPhysics;
    }

    private void Update()
    {
        jumpInput = input.GetInput(JUMP_BUTTON);
        jumpInput = input.GetInput(ALT_JUMP_BUTTON);
        jumpPhysics.DoJump(playerRigidbody, jumpInput, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == deathTag)
        {
            Death();
        }
    }

    private void Death()
    {
        OnDeath?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
