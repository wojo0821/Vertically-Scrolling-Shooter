using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;
    private GameObject _bullet;
    private bool isAttack = false;
    private bool canAttack = true;
    [SerializeField] private AudioClip bulletSound = null;

    private void Update()
    {
        if (isAttack && canAttack)
        {
            _bullet = Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canAttack = false;
            AudioManager.instance.audioSource3.clip = bulletSound;
            AudioManager.instance.audioSource3.Play();
            Destroy(_bullet, 1f);
            Invoke("ResetAttack", 0.1f);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            isAttack = true;
        }
        else if (context.canceled)
        {
            isAttack = false;
        }
    }
    private void ResetAttack()
    {
        canAttack = true;
    }
}
