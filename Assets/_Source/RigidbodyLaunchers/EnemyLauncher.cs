using System.Collections;
using UnityEngine;

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
            yield return new WaitForSeconds(spawnDelay);

            rb.gameObject.SetActive(true);
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
        }
    }
}
