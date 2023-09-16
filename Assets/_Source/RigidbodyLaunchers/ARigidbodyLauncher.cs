using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class ARigidbodyLauncher : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D spawnObjectPrefab;
    [SerializeField] protected float minSpawnDelay;
    [SerializeField] protected float maxSpawnDelay;
    [SerializeField] protected float launchForce;
    [SerializeField] protected uint amountToPool;
    
    protected List<Rigidbody2D> objects = new List<Rigidbody2D>();
    private bool isInitiated = false;

    protected abstract IEnumerator LaunchBody();
    public void StartLaunch()
    {
        StartCoroutine(LaunchBody());
    }

    protected APlayer player;

    [Inject]
    private void Construct(APlayer player)
    {
        this.player = player;
    }

    private void Start()
    {
        InitPool();
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

    public void InitPool()
    {
        if (!isInitiated)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                Rigidbody2D obj = Instantiate(spawnObjectPrefab);
                obj.gameObject.SetActive(false);
                objects.Add(obj);
            }
            isInitiated = true;
        }
    }

    public Rigidbody2D GetPooledObject()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].gameObject.activeInHierarchy)
            {
                return objects[i];
            }
        }
        return null;
    }
}
