using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] float aceleration;
    [SerializeField] float time;
    Vector2 direction = Vector2.right;
    Rigidbody2D rb2D;
    float distance;
    float elapsedTime = 0f;
    Vector2 startPosition;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        direction.Normalize();
    }

    private void Start()
    {
        startPosition = rb2D.position;
    }

    private void FixedUpdate()
    {
        if (elapsedTime < time)
        {
            elapsedTime += Time.fixedDeltaTime;

            distance = velocity * elapsedTime + 0.5f * aceleration * elapsedTime * elapsedTime;

            Vector2 newPosition = startPosition + direction * distance;

            rb2D.MovePosition(newPosition);
        }
    }
}
