using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab = null;
    [SerializeField] private float _bulletSpawnSpeed = 5f;
    [SerializeField] private float _bulletSpawnTimer = 0f;
    private float random_X;

    private void Update()
    {
        _bulletSpawnTimer += Time.deltaTime;
        if (_bulletSpawnTimer >= _bulletSpawnSpeed)
        {
            random_X = Random.Range(-2.8f, 2.8f);
            GameObject bullet = Instantiate(_bulletPrefab, new Vector3(random_X, transform.position.y, -1), Quaternion.identity);
            Destroy(bullet, 2.0f);
            _bulletSpawnTimer = 0f;
        }
    }
}
