using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool canAttack = true;
    
    // Use this for initialization
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity() {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.SetBool("attacking", false);
            return;
        }
        
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        canAttack = grounded;
        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
            canAttack = false;
        } else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0));
        if (flipSprite) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

        if (canAttack && Input.GetButtonDown("Fire1")) {
            animator.SetBool("attacking", true);
            ItensController item = gameObject.GetComponentInChildren<ItensController>();
            if (item != null) {
                item.action();
            }
        }
    }
}