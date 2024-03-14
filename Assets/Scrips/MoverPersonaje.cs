// Julio Cesar Vivas Medina A01749879

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadX = 5.0f; // float - 32 bits, double - 64 bits
    public float velocidadY = 5.0f;

    private Rigidbody2D rb2d; // Rigidbody2D es un componente del personaje
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // GetComponent es un método que se utiliza para obtener un componente de un objeto

    }

    // FixedUpdate se ejecuta cada 0.02 segundos
    void FixedUpdate() 
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            rb2d.velocity = new Vector2(velocidadX, rb2d.velocity.y);
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            rb2d.velocity = new Vector2(-velocidadX, rb2d.velocity.y);
        } else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        } if (Input.GetKey(KeyCode.Space) &&CheckGround.isGrounded) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, velocidadY);
        }
    }
}