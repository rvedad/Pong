using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8.0f;
    public KeyCode upKey;
    public KeyCode downKey;
    public float boundY = 4f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        if (Input.GetKey(upKey))
        {
            move = speed;
        }
        else if (Input.GetKey(downKey))
        {
            move = -speed;
        }
        rb.linearVelocity = new Vector2(0, move);
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -boundY, boundY));
    }
}
