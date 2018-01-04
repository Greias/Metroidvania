using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : PhysicsObject {
    public float distanceView = 10.0f;
    public float maxSpeed = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        Vector2 pos = rb2d.position;
        Vector2 player = GameObject.FindGameObjectWithTag("Player").transform.position;

        float distanceX = player.x - pos.x;
        float distanceY = player.y - pos.y;
        
        if (Mathf.Abs(distanceX) <= distanceView && Mathf.Abs(distanceY) <= distanceView) {
            move.x = maxSpeed * (distanceX / Mathf.Abs(distanceX));
        }
        
        bool flipSprite = (!spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0));
        if (flipSprite) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        targetVelocity = move;
    }
}
