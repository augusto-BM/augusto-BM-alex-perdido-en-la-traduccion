using UnityEngine;
using TMPro;

public class CanvasPuntos : MonoBehaviour
{
    public TextMeshProUGUI puntos;  // Para mostrar los puntos
    public GameObject[] vidas;     // Los corazones en el Canvas

    // Actualiza la visualización de los puntos
    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }

    // Activa el corazón correspondiente a la vida
    public void ActivarVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length)
        {
            vidas[indice].SetActive(true);
        }
    }

    // Desactiva el corazón correspondiente a la vida
    public void DesactivarVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length)
        {
            vidas[indice].SetActive(false);
        }
    }
}
