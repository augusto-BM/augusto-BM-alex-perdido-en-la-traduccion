using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPersonaje : MonoBehaviour
{
    private Rigidbody2D Myrb;
    public float spped;

    // Para poner sonido de muerte al enemigo
    public AudioClip sonidoMuerteEnemigo;

    // Dirección de disparo
    private Vector3 direccionDisparo;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el Rigidbody2D de la bala
        Myrb = GetComponent<Rigidbody2D>();

        // Buscar al jugador usando su Tag "Player"
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        // Verificar si se encontró al jugador
        if (jugador != null)
        {
            // Obtener la escala en el eje X del jugador
            float escalaX = jugador.transform.localScale.x;

            // Si la escala en X es positiva, el jugador está mirando a la derecha
            // Si la escala en X es negativa, el jugador está mirando a la izquierda
            if (escalaX > 0)
            {
                // Disparar a la derecha
                direccionDisparo = Vector3.right; 
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                // Disparar a la izquierda
                direccionDisparo = Vector3.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            // Establecer la velocidad de la bala en la dirección correcta
            Myrb.velocity = direccionDisparo * spped;
        }

        // Destruir la bala después de 1 segundo para evitar que se quede en la escena
        Destroy(gameObject, 1f);
    }

    // Método de colisión
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la bala colisiona con un objeto con la capa "Objetos"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Objetos"))
        {
            Destroy(gameObject);  // Destruir la bala si choca con un objeto
        }

        // Verifica si la bala colisiona con un objeto con la capa "Enemigo"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            // Sonido de muerte del enemigo
            ControladorAudios.Instance.ReproducirSonido(sonidoMuerteEnemigo);

            // Destruir el enemigo
            Destroy(collision.gameObject);

            // Destruir la bala
            Destroy(gameObject);
        }
    }
}
