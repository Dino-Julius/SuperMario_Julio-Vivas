// Julio Cesar Vivas Medina A01749879

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
    private float fixedVelocity = 0f;
    private float lastDirection = 1f; // 1f para derecha, -1f para izquierda

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
        float threshold = 0.01f; // Definir un umbral para la velocidad

        if (Mathf.Abs(rb.velocity.x) < threshold) {
            fixedVelocity = 0f;
        } else {
            fixedVelocity = rb.velocity.x;
            if (CheckGround.isGrounded) { // Solo actualizar la dirección si el personaje está en el suelo
                lastDirection = fixedVelocity > 0 ? 1f : -1f; // Actualizar la última dirección
            }
        }
        
        animator.SetFloat("velocidad", CheckGround.isGrounded ? Mathf.Abs(fixedVelocity) : 0); // Si el personaje está saltando, la velocidad es 0

        float horizontalInput = Input.GetAxis("Horizontal"); // Obtener la entrada del usuario para moverse horizontalmente
        if (!CheckGround.isGrounded && horizontalInput != 0) { // Si el personaje está saltando y el usuario está presionando una tecla para moverse
            spriteRenderer.flipX = horizontalInput < 0; // Voltear el sprite en función de la dirección de la entrada
        } else if (CheckGround.isGrounded || rb.velocity.y < 0) { // Si el personaje está en el suelo o está cayendo
            spriteRenderer.flipX = lastDirection < 0; // Usar la última dirección para determinar si se debe voltear el sprite
        }

        animator.SetBool("isJump", !CheckGround.isGrounded);
    }
}