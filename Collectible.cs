using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    public float rotationSpeed;   // Velocidad de rotacion del objeto
    public GameObject onCollectEffect;   // Efecto visual que aparece al recolectar


    void Start()
    {
   
    }


    void Update()
    {
        // Rota el objeto constantemente alrededor del eje Y
        transform.Rotate(0, 0.5f, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha tocado el coleccionable
        if (other.CompareTag("Player"))
        {
            // Destruye el objeto coleccionable
            Destroy(gameObject);


            // Instancia el efecto visual de coleccion
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}



