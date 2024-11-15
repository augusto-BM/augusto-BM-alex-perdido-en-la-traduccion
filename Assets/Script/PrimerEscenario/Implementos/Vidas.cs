using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            bool vidaRecuperada = ControladorPuntos.Instance.RecuperarVida();
            
            if(vidaRecuperada){
                Destroy(this.gameObject);
            }
        }
    } 
}
