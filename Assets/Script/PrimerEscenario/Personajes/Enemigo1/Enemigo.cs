using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private bool puedeAtacar = true;
    public float tiempoEsperaAtaque;
    private SpriteRenderer spriteRenderer;

    //Para poner sonido de colision con el enemigo
    public AudioClip sonidoColision;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {

            //Si no puede atacar, salimos de la función
            if (!puedeAtacar) return;

            //Desactivamos la posibilidad de atacar
            puedeAtacar = false;

            //Cambiamos la opacidad del enemigo
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;

            //Perdemos una vida 
            ControladorPuntos.Instance.PerderVida();

            //Para poner sonido de salto de nuestro controlador de audios
                ControladorAudios.Instance.ReproducirSonido(sonidoColision);

            //Aplicamos golpe al personaje
            other.gameObject.GetComponent<personajeMovimiento>().AplicarGolpe(); 

            Invoke("ReactivarAtaque", tiempoEsperaAtaque);
        }
    }

    void ReactivarAtaque(){
        puedeAtacar = true;

        //Cambiamos la opacidad del enemigo para recuperar la visibilidad
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}
