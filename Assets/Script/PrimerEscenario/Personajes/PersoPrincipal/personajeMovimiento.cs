using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeMovimiento : MonoBehaviour
{
    // Velocidad de movimiento
    public float velocidad = 5f;

    //Fuerza de salto
    public float fuerzaSalto = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    private bool enSuelo;

    //fuerza de impacto de colision con el enemigo
    public float fuerzaGolpe;
    private bool puedeMoverse = true;

    //Para poner sonido de salto de nuestro objeto peronaje
    public AudioClip sonidoSalto;

    private Rigidbody2D rb;

    // Solo si se quiere hacer animaciones
    /* private Animator anim; */

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Solo si se quiere hacer animaciones
        /* anim = GetComponent<Animator>(); */
    }

    void Update()
    {
        /* =================== MOVIMIENTO PERSONAJE =========================== */
            //Si no puede moverse porque es golpeado por el enemigo, no se ejecuta el movimiento
            if(!puedeMoverse) return;


            float moverObjeto = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moverObjeto * velocidad, rb.velocity.y);

            // Ajustar la escala según la dirección del movimiento
            if (moverObjeto > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moverObjeto < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }


        /* ===================================================================== */

        /* =================== SALTO PERSONAJE =========================== */
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
            enSuelo = hit.collider != null;
            if(enSuelo && Input.GetKeyDown(KeyCode.UpArrow)){
                rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);

                //Para poner sonido de salto de nuestro controlador de audios
                ControladorAudios.Instance.ReproducirSonido(sonidoSalto);
                
            }
        /* ===================================================================== */


        /* =================== ANIMACION PERSONAJE =========================== */

            // Solo si se quiere hacer animaciones
            /* if (moverObjeto != 0)
            {
                anim.SetBool("estaCorriendo", true);
            }
            else
            {
                anim.SetBool("estaCorriendo", false);
            } */
        /* ===================================================================== */

    }

    // Dibujar el raycast en el editor para el salto
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }

    //
    public void AplicarGolpe(){
        puedeMoverse = false;

        Vector2 direccionGolpe;
        if(rb.velocity.x >= 0){
            direccionGolpe = new Vector2(-1, 1);
        }else{
            direccionGolpe = new Vector2(1, 1);
        }

        rb.AddForce(direccionGolpe * fuerzaGolpe);
        StartCoroutine(EsperarYAtivarMovimiento());
    }

    IEnumerator EsperarYAtivarMovimiento(){
        yield return new WaitForSeconds(0.1f);

        while(!enSuelo){
            //Esperar al siguente frame
            yield return null;
        }

        //Si esta en el suelo, activar el movimiento
        puedeMoverse = true;
    }
    private bool EstaEnSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        return hit.collider != null;
    }
    
}
