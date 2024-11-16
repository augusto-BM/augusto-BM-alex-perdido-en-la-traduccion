using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance { get; private set; }

    public CanvasPuntos canvasPuntos;

    public int PuntosTotales { get ; private set;}

    //variable para las vidas inciales
    private int vidas = 3;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Evita que el objeto sea destruido al cambiar de escena
        }else{
            Destroy(gameObject);  // Elimina el objeto si ya existe una instancia
        } 

        // Inicializar los puntos con 50 al comenzar
        PuntosTotales = 50;
        canvasPuntos.ActualizarPuntos(PuntosTotales);
    }
    
    //PARA LAS MONEDAS
    public void SumarPuntos(int puntosASumar){
        PuntosTotales += puntosASumar;
        canvasPuntos.ActualizarPuntos(PuntosTotales);
    }

    //PARA LAS VIDAS
    public void PerderVida(){
        vidas--;
        if(vidas == 0){
            //Reiniciar el nivel
            /* SceneManager.LoadScene(2); */

            //Mostrar el canvas GameOver
            FindObjectOfType<GameOver>().MostrarGameOver();
        }
        canvasPuntos.DesactivarVida(vidas);
    }

    public bool RecuperarVida(){
        if(vidas == 3){
            return false;
        } 
        canvasPuntos.ActivarVida(vidas);
        vidas++;
        return true; 
    }

    // Método para reiniciar los puntos
    public void ReiniciarPuntos()
    {
        PuntosTotales = 50;  // Asignamos 50 puntos al reiniciar el juego.
    }

    // Método para reiniciar los puntos
    public void MenuPrincipal()
    {
        PuntosTotales = 50;  // Asignamos 50 puntos al reiniciar el juego.
    }
}
