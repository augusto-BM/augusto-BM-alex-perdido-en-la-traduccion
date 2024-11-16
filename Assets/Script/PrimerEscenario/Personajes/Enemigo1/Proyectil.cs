using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Transform player;
    private Rigidbody2D rb;

    //Para poner sonido de colision con el enemigo
    public AudioClip sonidoColision;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        DispararProyectil();
        
    }

    private void DispararProyectil()
    {
        Vector2 direccionAJugador = (player.position - transform.position).normalized;
        rb.velocity = direccionAJugador * velocidad;

        // Cambiar la escala del proyectil dependiendo de su dirección
        if (direccionAJugador.x < 0) 
        {
            Vector3 escalaActual = transform.localScale;
            escalaActual.x = Mathf.Abs(escalaActual.x) * -1; 
            transform.localScale = escalaActual;
        }
        else if (direccionAJugador.x > 0) 
        {
            Vector3 escalaActual = transform.localScale;
            escalaActual.x = Mathf.Abs(escalaActual.x); 
            transform.localScale = escalaActual;
        }

        StartCoroutine(DestruirProyectil());
    }

    IEnumerator DestruirProyectil()
    {
        float tiempoDestruccion = 2f;   
        yield return new WaitForSeconds(tiempoDestruccion);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ControladorPuntos.Instance != null)
            {
                /* Debug.Log("Colisión con el jugador detectada."); */
                ControladorPuntos.Instance.PerderVida();
                
                //Para poner sonido de salto de nuestro controlador de audios
                ControladorAudios.Instance.ReproducirSonido(sonidoColision);
            }
            else
            {
                Debug.LogError("ControladorPuntos no está inicializado.");
            }

            // Destruir el proyectil después de hacer daño
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
