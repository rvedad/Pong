using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8.0f;
    public KeyCode upKey;
    public KeyCode downKey;
    public float boundY = 4f;
    private Rigidbody2D rb;
    private float move = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = 0f;
        if (Input.GetKey(upKey)) move = 1f;
        if (Input.GetKey(downKey)) move = -1f;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, move * speed);
        float clampedY = Mathf.Clamp(rb.position.y, -boundY, boundY);
        rb.position = new Vector2(rb.position.x, clampedY);
    }
}
