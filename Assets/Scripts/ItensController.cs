using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensController : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxColider;

    void Start () {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxColider = GetComponent<BoxCollider2D>();
	}

    private void Update() {
        spriteRenderer.enabled = animator.GetCurrentAnimatorStateInfo(0).IsName("Action");
        boxColider.enabled = animator.GetCurrentAnimatorStateInfo(0).IsName("Action");
    }

    public void action() {
        animator.Play("Action");
    }
}
