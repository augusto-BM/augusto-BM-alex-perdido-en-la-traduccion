using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance { get; private set; }

    public CanvasPuntos canvasPuntos;

    public int PuntosTotales { get; private set; }
    private int vidas = 3;

    private static bool reinicioEscena = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (!reinicioEscena)
            {
                DontDestroyOnLoad(gameObject);  // Solo usar DontDestroyOnLoad si no es un reinicio de escena
            }
            InicializarValores();
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destrúyela
        }

        // Inicializar los puntos con 50 al comenzar
        PuntosTotales = 50;
        canvasPuntos.ActualizarPuntos(PuntosTotales);
    }

    void InicializarValores()
    {
        if (!reinicioEscena)
        {
            PuntosTotales = 50;
            vidas = 3;
            canvasPuntos.ActualizarPuntos(PuntosTotales);

            // Asegúrate de activar las 3 vidas
            for (int i = 0; i < 3; i++)
            {
                canvasPuntos.ActivarVida(i);
            }
        }
        else
        {
            reinicioEscena = false;  // Restablecer la bandera después de reiniciar
        }
    }

    // Método para resetear valores al reiniciar la escena
    public void ResetearValores()
    {
        reinicioEscena = true;  // Marcar que es un reinicio

        // Destruir el controlador de puntos antes de recargar la escena
        Destroy(gameObject);

        // Cargar la escena correcta
        SceneManager.LoadScene(2);

        // Iniciar la corutina para recrear el controlador después de un tiempo.
        StartCoroutine(RecrearControladorDespuésDeTiempo(10f)); // Esperar 10 segundos antes de recrear
    }

    private IEnumerator RecrearControladorDespuésDeTiempo(float tiempoEspera)
    {
        // Esperar el tiempo necesario antes de volver a crear el controlador
        yield return new WaitForSeconds(tiempoEspera);

        // Crear el controlador nuevamente
        GameObject controladorNuevo = new GameObject("ControladorPuntos");
        controladorNuevo.AddComponent<ControladorPuntos>();

        // Marcarlo como persistente entre escenas
        DontDestroyOnLoad(controladorNuevo);
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        canvasPuntos.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidas--;
        if (vidas < 0) vidas = 0;

        if (vidas == 0)
        {
            // Mostrar Game Over
            FindObjectOfType<GameOver>().MostrarGameOver();
        }

        if (vidas >= 0 && vidas < canvasPuntos.vidas.Length)
        {
            canvasPuntos.DesactivarVida(vidas);
        }
    }

    public bool RecuperarVida()
    {
        if (vidas < 3)
        {
            // Activar la vida en el Canvas (vida que se acaba de recuperar)
            canvasPuntos.ActivarVida(vidas);
            vidas++;
            return true;
        }
        return false;
    }

    public void ReiniciarPuntos()
    {
        PuntosTotales = 50;  // Asignamos 50 puntos al reiniciar el juego.
    }

    public void MenuPrincipal()
    {
        PuntosTotales = 50;  // Asignamos 50 puntos al reiniciar el juego.
    }

    // Método para destruir el controlador cuando ya no se necesite
    public void DestruirControlador()
    {
        reinicioEscena = false;
        Destroy(gameObject);  // Destruir el objeto del controlador cuando ya no se necesite
    }
}
