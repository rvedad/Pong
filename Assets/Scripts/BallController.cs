using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Ball Settings")]
    public float initialSpeed = 10.0f;
    private float speed = 0;
    public float maxSpeed = 20.0f;
    public float speedIncrease = 0.5f;
    public float resetDelay = 1f;
    private Rigidbody2D rb;

    [Header("Audio")]
    public AudioClip paddleHitSound;
    public AudioClip wallHitSound;
    private AudioSource audioSource;
    private TrailRenderer trail;

    void Start()
    {
        speed = initialSpeed;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        trail = GetComponent<TrailRenderer>();
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
        if (collision.gameObject.CompareTag("Paddle"))
        {
            speed = Mathf.Min(speed + speedIncrease, maxSpeed);
            audioSource.PlayOneShot(paddleHitSound);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(wallHitSound);
        }

        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    public void ResetBall()
    {
        trail.enabled = false;
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;
        speed = initialSpeed;
        Invoke("EnableTrailAndLaunchBall", resetDelay);
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;
        trail.enabled = false;
    }

    void EnableTrailAndLaunchBall()
    {
        trail.enabled = true;
        LaunchBall();
    }
}
