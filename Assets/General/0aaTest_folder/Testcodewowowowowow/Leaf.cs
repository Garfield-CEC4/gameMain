using UnityEngine;

public class Leaf : MonoBehaviour, IWindAffected
{
    public float swayAmount = 0.1f; // ความมากน้อยของการแกว่ง
    public float swaySpeed = 1f; // ความเร็วในการแกว่ง

    private Vector3 initialPosition;
    private float swayOffset;

    void Start()
    {
        initialPosition = transform.localPosition; // บันทึกตำแหน่งเริ่มต้นของใบไม้
    }

    void Update()
    {
        // ใช้แรงลมในการแกว่งใบไม้
        swayOffset = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        // การใช้ Vector3 เพื่อรวมตำแหน่งเริ่มต้นและการเคลื่อนไหว
        transform.localPosition = initialPosition + new Vector3(swayOffset, 0, 0);
    }

    // Implement เมธอดจาก IWindAffected
    public void ApplyWind(Vector2 windForce)
    {
        // ใช้แรงลมในการปรับค่าของ swayAmount และ swaySpeed ตามความแรงของลม
        swayAmount = Mathf.Clamp(swayAmount + windForce.x * 0.01f, 0, 0.5f);
        swaySpeed = Mathf.Clamp(swaySpeed + windForce.x * 0.01f, 0.5f, 2f);
    }
}