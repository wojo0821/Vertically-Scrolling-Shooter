using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;

    private void FixedUpdate()
    {
        transform.position += Vector3.down * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet hit: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
