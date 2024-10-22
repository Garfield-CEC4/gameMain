
using UnityEngine;

public class attackG : MonoBehaviour
{
    public float speed = 5f; // ความเร็วของการเคลื่อนที่
    public float stopDelay = 1f; // เวลาที่จะหยุดก่อน
    private Vector3 originalPosition; // ตำแหน่งเริ่มต้น
    private bool canClick = true; // เช็คว่าอนุญาตให้คลิกหรือไม่

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้น
        originalPosition = transform.position;
    }

    void Update()
    {
        // ตรวจสอบว่ามีการคลิกเมาส์หรือไม่และสามารถคลิกได้
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            // รับตำแหน่งของเมาส์ในโลก
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // ตั้งค่า z เป็น 0 เพราะเราอยู่ใน 2D

            // เรียกใช้ coroutine เพื่อเคลื่อนที่
            StartCoroutine(MoveToPosition(mousePosition));
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        canClick = false; // ปิดการคลิก

        // เคลื่อนที่ไปยังตำแหน่งของเมาส์
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // เคลื่อนที่ไปยังตำแหน่งของเมาส์
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; // รอ frame ถัดไป
        }

        // รอเวลาที่กำหนดก่อนกลับไปยังตำแหน่งเดิม
        yield return new WaitForSeconds(stopDelay);

        // เคลื่อนที่กลับไปยังตำแหน่งเริ่มต้น
        while (Vector3.Distance(transform.position, originalPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
            yield return null; // รอ frame ถัดไป
        }

        canClick = true; // อนุญาตให้คลิกอีกครั้ง
    }
}
