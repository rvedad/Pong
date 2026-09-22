using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10.0f;
    public float resetDelay = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -0.5f : 0.5f;
        rb.linearVelocity = new Vector2(x, y).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;
        Invoke("LaunchBall", resetDelay);
    }
}
