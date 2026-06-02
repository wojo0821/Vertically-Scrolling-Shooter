using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 10.0f;
    private void FixedUpdate()
    {
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }

}
