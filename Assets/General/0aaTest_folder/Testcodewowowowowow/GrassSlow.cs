using UnityEngine;

public class GrassSlow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // ตรวจสอบว่า Collider ที่อยู่ใน Trigger มี tag ว่า "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            // ทำสิ่งที่ต้องการเมื่อ Player อยู่ในพื้นที่ Trigger
            Debug.Log("Player is staying in the trigger area!");

            // ตัวอย่างการกระทำ เช่น: ลดพลังชีวิต, เพิ่มคะแนน, หรือเปลี่ยนสถานะ
            // Example: Reduce player health
            // other.GetComponent<PlayerHealth>().ReduceHealth(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
