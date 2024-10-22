using UnityEngine;

public class WindAffectedObject : MonoBehaviour, IWindAffected
{
    public float movementSpeed = 1f; // ความเร็วในการเคลื่อนที่ของวัตถุ
    private Vector2 windVelocity;

    void Update()
    {
        // ใช้แรงลมในการเคลื่อนที่ของวัตถุ
        transform.position += (Vector3)windVelocity * Time.deltaTime;
    }

    // Implement เมธอดจาก IWindAffected
    public void ApplyWind(Vector2 windForce)
    {
        windVelocity = windForce;
    }
}
