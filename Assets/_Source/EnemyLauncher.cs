using System.Collections;
using UnityEngine;
using Zenject.SpaceFighter;

public class EnemyLauncher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float flySpeed;
    
    private Player player;
    private Vector3 direction;
    private Rigidbody2D spawnedEnemy;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        StartCoroutine(LaunchEnemy());
    }

    private void OnEnable()
    {
        player.OnDeath += Death;
    }
    private void OnDisable()
    {
        player.OnDeath -= Death;
    }

    private void Update()
    {
        direction = player.transform.position - transform.position;
    }

    private IEnumerator LaunchEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            spawnedEnemy = Instantiate(rb, transform);
            spawnedEnemy.AddForce(direction * flySpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void Death()
    {
        StopAllCoroutines();
    }
}
