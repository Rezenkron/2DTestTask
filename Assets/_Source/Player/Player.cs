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
    private GameStateMachine gameStateMachine;
    private StateGame stateGame;

    public event Action OnDeath;

    [Inject]
    private void Construct(IInputHandler input, JumpPhysics jumpPhysics, GameStateMachine gameStateMachine, StateGame stateGame)
    {
        this.input = input;
        this.jumpPhysics = jumpPhysics;
        this.gameStateMachine = gameStateMachine;
        this.stateGame = stateGame;
    }

    private void Start()
    {
        gameStateMachine.Initialize(new StatePause());
    }

    private void Update()
    {
        jumpInput = input.GetInput(JUMP_BUTTON);
        jumpInput = input.GetInput(ALT_JUMP_BUTTON);
        if (gameStateMachine.CurrentState is StatePause && jumpInput > 0)
        {
            gameStateMachine.ChangeState(stateGame);
        }
        print(jumpInput);
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
