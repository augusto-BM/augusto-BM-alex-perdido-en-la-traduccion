using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoIA : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float minimadistancia;
    [SerializeField] private float distanciaMaxima; // Nueva variable para la distancia máxima
    [SerializeField] private Transform player;

    //Para poner sonido de colision con el enemigo
    public AudioClip sonidoColision;

    private bool estaMirandoDerecha = true;
    
    // Update is called once per frame
    void Update()
    {
        Seguimiento();
        
        bool mirandoDerecha = transform.position.x < player.position.x;

        Flip(mirandoDerecha);    
    }

    private void Seguimiento()
    {
        // Verifica si la distancia está dentro del rango para seguir
        float distanciaActual = Vector2.Distance(transform.position, player.position);
        
        if (distanciaActual > minimadistancia && distanciaActual < distanciaMaxima)
        {
            // El enemigo sigue al jugador solo si está dentro del rango
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        else if (distanciaActual <= minimadistancia)
        {
            // Si el jugador está muy cerca, el enemigo retrocede
            Retroceder();
        }
    }

    private void Retroceder()
    {
        // Verifica la posición relativa del jugador para determinar en qué dirección retroceder.
        if (player.position.x < transform.position.x)
        {
            // Si el jugador está a la izquierda, el enemigo se mueve hacia la derecha.
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1f, transform.position.y), velocidad * Time.deltaTime);
        }
        else if (player.position.x > transform.position.x)
        {
            // Si el jugador está a la derecha, el enemigo se mueve hacia la izquierda.
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1f, transform.position.y), velocidad * Time.deltaTime);
        }
    }



    private void Flip(bool mirandoDerecha)
    {
        if (mirandoDerecha && !estaMirandoDerecha || !mirandoDerecha && estaMirandoDerecha)
        {
            estaMirandoDerecha = !estaMirandoDerecha;

            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
