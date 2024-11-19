using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPersonaje : MonoBehaviour
{
    private Rigidbody2D Myrb;
    public float spped;
    
    // Start is called before the first frame update
    void Start()
    {
        Myrb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Myrb.velocity = new Vector2(+spped, 0); */
        Myrb.velocity = transform.right * spped;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la bala colisiona con un objeto con la capa "Enemigo"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Objetos"))
        {
            // Destruye la bala
            Destroy(gameObject);
        }

        
        // Verifica si la bala colisiona con un objeto con la capa "Enemigo"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            // Destruye el enemigo
            Destroy(collision.gameObject);

            // Destruye la bala
            Destroy(gameObject);
        }
    }

}
