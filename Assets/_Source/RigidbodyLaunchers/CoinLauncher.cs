using System.Collections;
using UnityEngine;

public class CoinLauncher : ARigidbodyLauncher
{
    [SerializeField] float minY, maxY; 
    private void Start()
    {
        StartCoroutine(LaunchBody());
    }

    protected override IEnumerator LaunchBody()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            rb.gameObject.SetActive(true);
            transform.position = new Vector2(transform.position.x, Random.Range(maxY, minY));
            rb.AddForce(Vector2.left * launchForce, ForceMode2D.Impulse);
        }
    }
}
