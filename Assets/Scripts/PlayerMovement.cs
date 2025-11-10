using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteAnimator animator;
    public Vector2 direction;
    public float speed;
    
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<SpriteAnimator>();
    }

    private void Update()
    {
        direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
            animator.PlayAnimation("WalkUp");
        } else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
            animator.PlayAnimation("WalkDown");
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            animator.PlayAnimation("WalkLeft");
        } else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            animator.PlayAnimation("WalkRight");
        }

        if (direction == Vector2.zero)
        {
            animator.PlayAnimation("Idle");
        }
    }

    private void FixedUpdate() 
    {
        rigidBody2D.AddForce(direction.normalized * (speed * Time.fixedDeltaTime));
    }
}
