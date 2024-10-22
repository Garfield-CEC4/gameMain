using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_garfield : MonoBehaviour
{
    public float speed;
    float movementX;
    float movementY;

    Rigidbody2D rb;
    Animator anim;

    

    //Animation
    bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        AnimationController();

        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");


        if (movementX != 0 || movementY != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementX, movementY) * speed;
    }
    void AnimationController()
    {
        anim.SetFloat("X", movementX);
        anim.SetFloat("Y", movementY);

        anim.SetBool("isMoving", isMoving);
    }
}
