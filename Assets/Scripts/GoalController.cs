using UnityEngine;

public class GoalController : MonoBehaviour
{
    public int player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.instance.AddScore(player);
        }
    }
}
