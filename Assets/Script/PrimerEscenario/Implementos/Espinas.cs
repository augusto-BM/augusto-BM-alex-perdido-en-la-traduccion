using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    //Para poner sonido de colision con el enemigo
    public AudioClip sonidoColision;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){

            //Perdemos una vida
            ControladorPuntos.Instance.PerderVida();

            //Para poner sonido de salto de nuestro controlador de audios
            ControladorAudios.Instance.ReproducirSonido(sonidoColision);
        }
    } 
}
