using System.Collections;
using UnityEngine;

public class DispararIA : MonoBehaviour
{

    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float tiempoEntreDisparos;

    [SerializeField] private float distanciaDisparo; // Nueva variable para la distancia mínima de disparo
    [SerializeField] private Transform player; // Referencia al jugador

    //Para poner sonido de colision con el enemigo
    public AudioClip sonidoDisparoEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        // Asigna el jugador automáticamente usando su tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (player == null)
        {
            Debug.LogError("No se encontró un GameObject con el tag 'Player'. Asegúrate de que el jugador tiene este tag.");
        }

        StartCoroutine(Disparar());

    }

    IEnumerator Disparar()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreDisparos);

            // Comprobar la distancia entre el enemigo y el jugador
            float distanciaActual = Vector2.Distance(transform.position, player.position);
            
            // Si el jugador está dentro del rango, dispara
            if (distanciaActual <= distanciaDisparo)
            {
                // Instanciamos el proyectil
                Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

                // Reproducimos el sonido de disparo
                if (sonidoDisparoEnemigo != null)
                {
                    ControladorAudios.Instance.ReproducirSonido(sonidoDisparoEnemigo);
                }
            }
        }
    }
}
