using UnityEngine;

public class AIController : MonoBehaviour
{

    [Header("AI Settings")]
    public float easySpeed = 3.0f;
    public float mediumSpeed = 6.0f;
    public float hardSpeed = 10.0f;
    public float boundY = 4.0f;

    private float currentSpeed;
    private Rigidbody2D rb;
    private Transform ballTransform;
    private Rigidbody2D ballRb;
    private bool isAIEnabled = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        string difficulty = PlayerPrefs.GetString("Difficulty", "Medium");
        switch (difficulty)
        {
            case "Easy":
                currentSpeed = easySpeed;
                break;
            case "Medium":
                currentSpeed = mediumSpeed;
                break;
            case "Hard":
                currentSpeed = hardSpeed;
                break;
            default:
                currentSpeed = mediumSpeed;
                break;
        }

        ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
        ballRb = ballTransform.GetComponent<Rigidbody2D>();

    }

    public void ActivateAI()
    {
        isAIEnabled = true;
    }

    public void DeactivateAI()
    {
        isAIEnabled = false;
        rb.linearVelocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (!isAIEnabled || ballTransform == null)
        {
            return;
        }

        float ballVelocityX = ballRb.linearVelocity.x;
        bool ballMovingTowardsAI = IsBallMovingTowardsAI(ballVelocityX);

        if (ballMovingTowardsAI)
        {
            TrackBall();
        }
        else
        {
            ReturnToCenter();
        }

        float clampedY = Mathf.Clamp(rb.position.y, -boundY, boundY);
        rb.position = new Vector2(rb.position.x, clampedY);
    }

        bool IsBallMovingTowardsAI(float ballVelocityX)
        {
            bool aiOnRight = transform.position.x > 0;
            return aiOnRight ? ballVelocityX > 0 : ballVelocityX < 0;
        }

        void TrackBall()
        {
            float direction = 0f;

            if (ballTransform.position.y > transform.position.y + 0.1f)
            {
                direction = 1f;
            }
            else if (ballTransform.position.y < transform.position.y - 0.1f)
            {
                direction = -1f;
            }

            SetVerticalVelocity(direction, currentSpeed);
        }

        void SetVerticalVelocity(float direction, float speed)
        {
            rb.linearVelocity = new Vector2(0, direction * speed);
        }

        void ReturnToCenter()
        {
            if (Mathf.Abs(transform.position.y) < 0.1f)
            {
                SetVerticalVelocity(0, 0);
                return;
            }
            float direction = transform.position.y > 0 ? -1f : 1f;
            SetVerticalVelocity(direction, currentSpeed * 0.5f);
        }
    }
