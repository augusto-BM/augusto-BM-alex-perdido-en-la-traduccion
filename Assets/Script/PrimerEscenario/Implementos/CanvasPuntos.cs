using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasPuntos : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public GameObject[] vidas;

    // Update is called once per frame
    void Start()
    {
        // Al iniciar, actualizar los puntos con el valor actual del ControladorPuntos-taboada          
        if (ControladorPuntos.Instance != null)
        {
            ActualizarPuntos(ControladorPuntos.Instance.PuntosTotales);
        }
    }
    void Update()
    {
        puntos.text = ControladorPuntos.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int  puntosTotales){
        puntos.text = puntosTotales.ToString();
    }

    public void DesactivarVida(int indice){
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice){
        vidas[indice].SetActive(true);
    }
}
