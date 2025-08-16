using UnityEngine;


// Controla el movimiento y la rotacion del jugador
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;    // Velocidad de movimiento del jugador
    public float rotationSpeed = 120.0f  ; // Velocidad de rotacion del jugador


    private Rigidbody rb;  // Referencia al Rigidbody del jugador




    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody
    }


 
    void Update()
    {
       
    }


    // Se ejecuta en intervalos fijos, ideal para fisica!!
    private void FixedUpdate()
    {
        // Mueve al jugador segun la entrada vertical (W/S o flechas)
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);


        // Rota al jugador segun la entrada horizontal (A/D o flechas)
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}



