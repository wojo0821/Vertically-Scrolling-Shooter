using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector2 _moveInput;
    private float _airdrag = 0.5f;

    private void Update()
    {
        ClampPosition();
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(_moveInput.x, _moveInput.y * _airdrag, 0) * _moveSpeed * Time.deltaTime;
    }
    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        if (_moveInput.y > 0)
        {
            _airdrag = 0.5f;
        }
        else
        {
            _airdrag = 1f;
        }
    }
    private void ClampPosition()
    {
        Vector3 position = transform.position;

        Vector3 minBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float paddingX = 0f;
        float paddingY = 0.5f;

        position.x = Mathf.Clamp(position.x, minBoundary.x + paddingX, maxBoundary.x - paddingX);
        position.y = Mathf.Clamp(position.y, minBoundary.y + paddingY, maxBoundary.y - paddingY);

        transform.position = position;
    }
}
