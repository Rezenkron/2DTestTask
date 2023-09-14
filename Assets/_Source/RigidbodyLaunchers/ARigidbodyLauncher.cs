using System.Collections;
using UnityEngine;
using Zenject;

public abstract class ARigidbodyLauncher : MonoBehaviour 
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected float launchForce;
    protected abstract IEnumerator LaunchBody();
    public void StartLaunch()
    {
        StartCoroutine(LaunchBody());
    }

    protected Player player;

    [Inject]
    private void Construct(Player player)
    {
        this.player = player;
    }

    private void OnEnable()
    {
        player.OnDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        player.OnDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        StopCoroutine(LaunchBody());
    }
}
