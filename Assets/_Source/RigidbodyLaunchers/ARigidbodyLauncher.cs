using System.Collections;
using UnityEngine;

public abstract class ARigidbodyLauncher : MonoBehaviour 
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected float launchForce;
    protected abstract IEnumerator LaunchBody();


    protected Player player;

    private void OnEnable()
    {
        player.OnDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        player.OnDeath -= OnPlayerDeath;
    }

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnPlayerDeath()
    {
        StopCoroutine(LaunchBody());
    }
}
