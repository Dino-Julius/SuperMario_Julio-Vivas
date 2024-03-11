using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadX = 2.0f; // float - 32 bits, double - 64 bits
    public float velocidadY = 3.5f;

    // public LayerMask suelo;
    // public CircleCollider2D circleColider;

    private Rigidbody2D rb2d; // Rigidbody2D es un componente del personaje
    // Start is called before the first frame update
    void Start()
    {
        // print("Prueba Unity - VSCODE");
        rb2d = GetComponent<Rigidbody2D>(); // GetComponent es un método que se utiliza para obtener un componente de un objeto

    }

    // FixedUpdate se ejecuta cada 0.02 segundos
    void FixedUpdate() 
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(velocidadX, rb2d.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-velocidadX, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) &&CheckGround.isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, velocidadY);
        }

        // if (Input.GetKey(KeyCode.Space) && circleColider.IsTouchingLayers(suelo))
        // {
        //     rb2d.velocity = new Vector2(rb2d.velocity.x, velocidadY);
        // }
        // // // [-1, +1]
        // // float movHorizontal = Input.GetAxis("Horizontal"); // Obtener el valor de los ejes horizontal y vertical
        // // rb.velocity = new Vector2(movHorizontal * velocidadX, rb.velocity.y); // Mover el personaje en el eje X
        // // // Obtiene el valor de entrada del eje vertical
        // // float movVertical = Input.GetAxis("Vertical");
        // // rb.velocity = new Vector2(rb.velocity.x, movVertical * velocidadY); // Mover el personaje en el eje Y

        // // if (movVertical != 0) {
        // //     rb.velocity = new Vector2(rb.velocity.x, movVertical * velocidadY);
        // // } else {
        //   //     rb.velocity = new Vector2(rb.velocity.x, 0);
        // // }

        // // [-1, +1]
        // float  movHorizontal = Input.GetAxis("Horizontal"); // Obtener el valor del eje horizontal
        // float movVertical = Input.GetAxis("Vertical"); // Obtener el valor del eje vertical

        // float vY = rb.velocity.y; // Obtener la velocidad actual del personaje en el eje Y
        // if (movVertical != 0) {
        //     vY = movVertical * velocidadY; // Asignar la velocidad en el eje Y
        // }

        // rb.velocity = new Vector2(movHorizontal * velocidadX, vY); // Mover el personaje en el eje X
    }

    // Update is called once per frame
    // void Update() {
    //     float movHorizontal = Input.GetAxis("Horizontal"); // Obtener el valor del eje horizontal
    //     transform.Translate(Vector2.right * Time.deltaTime * velocidadX * movHorizontal); // Mover el personaje en el eje X

    //     float movVertical = Input.GetAxis("Vertical"); // Obtener el valor del eje vertical
    //     transform.Translate(Vector2.up * Time.deltaTime * velocidadY * movVertical); // Mover el personaje en el eje Y
    // }
}