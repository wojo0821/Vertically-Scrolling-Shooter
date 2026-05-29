using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;

    void FixedUpdate()
    {

        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y < endPosition.y)
        {
            float overshoot = transform.position.y - endPosition.y;
            transform.position = new Vector2(startPosition.x, startPosition.y + overshoot);
        }
    }
}
