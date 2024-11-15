using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEfecto : MonoBehaviour
{
    [SerializeField] private float parallaxVelocidad;

    private Transform camaraTransform;
    private Vector3 previaPosicionCamara;
    private float anchoSprite, posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        camaraTransform = Camera.main.transform;
        previaPosicionCamara = camaraTransform.position;

        anchoSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        posicionInicial = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltax = (camaraTransform.position.x - previaPosicionCamara.x) * parallaxVelocidad;
        float moverX = (camaraTransform.position.x * (1 - parallaxVelocidad));

        transform.Translate(new Vector3(deltax, 0, 0));
        previaPosicionCamara = camaraTransform.position;

        if(moverX > posicionInicial + anchoSprite){
            transform.Translate(new Vector3(anchoSprite, 0, 0));
            posicionInicial += anchoSprite;
        }else if(moverX < posicionInicial - anchoSprite){
            transform.Translate(new Vector3(-anchoSprite, 0, 0));
            posicionInicial -= anchoSprite;
        }
    }
}
