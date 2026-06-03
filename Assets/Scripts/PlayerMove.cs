using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private AudioClip movesound = null;
    [SerializeField] private Rigidbody2D rb = null;

    private float nowPitch = 1f;
    private Vector2 _moveInput;
    private float _airdrag = 0.5f;
    private float propellerspeed = 1f;

    private void Start()
    {
        AudioManager.instance.SoundPlay(movesound);
    }
    private void Update()
    {
        ClampPosition();
        nowPitch = Mathf.Lerp(nowPitch, propellerspeed, 2.0f * Time.deltaTime);
        AudioManager.instance.audioSource.pitch = nowPitch;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(_moveInput.x, _moveInput.y * _airdrag, 0) * _moveSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        if (_moveInput.y > 0)
        {
            _airdrag = 0.5f;
            propellerspeed = 1.2f;
        }
        else if (_moveInput.y < 0)
        {
            _airdrag = 1f;
            propellerspeed = 0.8f;
        }
        else
        {
            _airdrag = 1f;
            propellerspeed = 1f;
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
