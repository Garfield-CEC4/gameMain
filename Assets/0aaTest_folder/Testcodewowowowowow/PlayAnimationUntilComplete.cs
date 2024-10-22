using UnityEngine;
using System.Collections;

public class PlayAnimationUntilComplete : MonoBehaviour
{
    public Animator animator;
    public string animationTriggerName = "TEST";



    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            animator.SetTrigger(animationTriggerName);
        }
        
        // ตรวจสอบสถานะของเกม

    }


}