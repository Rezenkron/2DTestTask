using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyLauncher launcher;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = launcher.transform.position;
        gameObject.SetActive(false);
    }
}
