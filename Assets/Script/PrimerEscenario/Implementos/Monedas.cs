using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public int valor = 1;

    //Para poner sonido de moneda desde el objeto moneda
    public AudioClip sonidoMoneda;

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.CompareTag("Player")){
            ControladorPuntos.Instance.SumarPuntos(valor);
            Destroy(this.gameObject);

            //Para poner sonido de moneda de nuestro controlador de audios
            ControladorAudios.Instance.ReproducirSonido(sonidoMoneda);


        }
    }
}
