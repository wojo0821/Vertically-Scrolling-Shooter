using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet = null;
    private bool isAttack = false;
    private bool canAttack = true;

    private void Update()
    {
        if (isAttack && canAttack)
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canAttack = false;
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
