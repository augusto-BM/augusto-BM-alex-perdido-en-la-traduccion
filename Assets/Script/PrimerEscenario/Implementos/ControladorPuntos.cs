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
        }else{
            Debug.Log("Ya existe una instancia de ControladorPuntos");
        } 
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
            SceneManager.LoadScene(1);
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
}
