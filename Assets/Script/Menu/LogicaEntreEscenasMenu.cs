using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEntreEscenasMenu : MonoBehaviour
{
    private void Awake()
    { 
        var noDestruirEntreEscenas = FindObjectsOfType<LogicaEntreEscenasMenu>();
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
