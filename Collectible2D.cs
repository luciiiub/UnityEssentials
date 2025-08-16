using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    public float rotationSpeed = 0.5f; // Velocidad de rotacion
    public GameObject onCollectEffect; // Efecto que aparece al recoger el objeto

  
    void Update()
    {
        // Rotar el objeto
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Revisar si el otro objeto tiene el componente PlayerController2D
        if (other.GetComponent<PlayerController2D>() != null) 
        {
            // Destruir el objeto recolectable
            Destroy(gameObject);

            // Instanciar el efecto de particulas
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
