using UnityEngine;

public class CenterLine : MonoBehaviour
{
    [Header("Dash Settings")]
    public GameObject dashPrefab;
    public int dashCount = 16;
    public float dashSpacing = 1.0f;

    void Start()
    {
        DrawCenterLine();
    }

    void DrawCenterLine()
    {
        float totalHeight = dashCount * dashSpacing;
        float startY = totalHeight / 2.0f;

        for (int i = 0; i < dashCount; i++)
        {
            float yPos = startY - (i * dashSpacing);
            Instantiate(dashPrefab, new Vector3(0, yPos, 0), Quaternion.identity, transform);
        }

    }
}
