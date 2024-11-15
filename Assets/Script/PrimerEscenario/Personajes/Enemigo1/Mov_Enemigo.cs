using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Enemigo : MonoBehaviour
{
    public float speed;
    public bool esDerecha;
    public float contadorTime;
    public float tiempoParaCambiar;
    // Start is called before the first frame update
    void Start()
    {

        contadorTime = tiempoParaCambiar;
    }

    // Update is called once per frame
    void Update()
    {

        //PARA EL MOVIMIENTO DEL ENEMIGO DERECHA E IZQUIERDA
        if (esDerecha == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1,1,1);
        }

        if (esDerecha == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);

        }

        contadorTime -= Time.deltaTime;

        //CAMBIO DE DIRECCION
        if (contadorTime <= 0)
        {
            contadorTime = tiempoParaCambiar;
            esDerecha = !esDerecha;
        }
        
    }
}
