using System.Collections;
using UnityEngine;

public class CoinLauncher : ARigidbodyLauncher
{
    [SerializeField] private float minY, maxY; 

    protected override IEnumerator LaunchBody()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));

            Rigidbody2D coin = GetPooledObject();
            if (coin != null)
            {
                coin.transform.position = gameObject.transform.position;
                coin.gameObject.SetActive(true);
                transform.position = new Vector2(transform.position.x, Random.Range(maxY, minY));
                coin.AddForce(Vector2.left * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}
