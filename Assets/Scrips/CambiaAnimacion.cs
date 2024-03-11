using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaAnimacion : MonoBehaviour
{
    // Declarar una referenica al Animator
    private Animator animator;
    private Rigidbody2D rb; // Declare a reference to the Rigidbody2D component
    // Declarar una referencia al componente SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar la referencia al componente Animator
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Initialize the 'rb' variable
        spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize the 'spriteRenderer' variable
    }

    void FixedUpdate()
    {
        animator.SetFloat("velocidad", Mathf.Abs(rb.velocity.x)); // Use the absolute value of rb.velocity.x
        spriteRenderer.flipX = rb.velocity.x < 0;
        animator.SetBool("isJump", !CheckGround.isGrounded);
        // if (rb.velocity.x > 0)
        // {
        //     spriteRenderer.flipX = false; // Set the flipX property to false
        // }
        // else if (rb.velocity.x < 0)
        // {
        //     spriteRenderer.flipX = true; // Set the flipX property to true
        // }

    }
}
