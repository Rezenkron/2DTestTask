using System.Collections;
using UnityEngine;
using Zenject.SpaceFighter;

public class EnemyLauncher : ARigidbodyLauncher
{
    private Vector3 direction;

    private void Update()
    {
        direction = player.transform.position - transform.position;
    }

    protected override IEnumerator LaunchBody()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));

            Rigidbody2D enemy = GetPooledObject();
            if(enemy != null)
            {
                enemy.transform.position = gameObject.transform.position;
                enemy.gameObject.SetActive(true);
                enemy.AddForce(direction * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}
