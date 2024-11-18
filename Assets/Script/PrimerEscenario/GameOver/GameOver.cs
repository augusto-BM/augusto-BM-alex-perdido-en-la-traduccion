using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text puntosTexto;
    public GameObject gameOverPanel;

    public void MostrarGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        puntosTexto.text = "Puntos: " + ControladorPuntos.Instance.PuntosTotales;
    }

    public void ReiniciarNivel()
    {
        // Resetear los valores y reiniciar la escena
        ControladorPuntos.Instance.ResetearValores();
        // Reiniciar los puntos a 50 cuando se reinicia el nivel
        ControladorPuntos.Instance.ReiniciarPuntos();
        Time.timeScale = 1;
    }

    public void IrAlMenuPrincipal()
    {
        ControladorPuntos.Instance.MenuPrincipal();
        Time.timeScale = 1;

        // Destruir todos los objetos en la escena antes de cambiar a la nueva escena
        DestroyAllObjects();

        SceneManager.LoadScene(0);  // Cambiar al menú principal
    }

    private void DestroyAllObjects()
    {
        // Obtener todos los objetos en la escena
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            // Si el objeto es marcado con DontDestroyOnLoad, también se destruirá
            Destroy(obj);
        }
    }
}
