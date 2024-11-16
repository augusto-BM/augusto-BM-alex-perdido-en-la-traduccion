using System.Collections;
using UnityEngine;

public class DispararIA : MonoBehaviour
{

    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float tiempoEntreDisparos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());   
    }

    IEnumerator Disparar()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreDisparos);
            Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
        }
    }
}
