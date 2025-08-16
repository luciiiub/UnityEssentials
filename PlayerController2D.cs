using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    
    public float speed = 5f; // Velocidad a la que se mueve el jugador
    public bool canMoveDiagonally = true; // Controla si el jugador puede moverse en diagonal

    
    private Rigidbody2D rb;
    private Vector2 movement; 
    private bool isMovingHorizontally = true; //Para saber si el jugador se mueve horizontalmente

    void Start()
    {
        // Inicializar el Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        // Evitar que el jugador rote
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Obtener la entrada del jugador desde teclado o control
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Revisar si el movimiento diagonal esta permitido
        if (canMoveDiagonally)
        {
            // Establecer la direccion de movimiento segun la entrada
            movement = new Vector2(horizontalInput, verticalInput);
            // Opcionalmente rotar al jugador segun la direccion
            RotatePlayer(horizontalInput, verticalInput);
        }
        else
        {
            // Determinar la prioridad de movimiento segun la entrada
            if (horizontalInput != 0)
            {
                isMovingHorizontally = true;
            }
            else if (verticalInput != 0)
            {
                isMovingHorizontally = false;
            }

            // Establecer direccion y rotar al jugador
            if (isMovingHorizontally)
            {
                movement = new Vector2(horizontalInput, 0);
                RotatePlayer(horizontalInput, 0);
            }
            else
            {
                movement = new Vector2(0, verticalInput);
                RotatePlayer(0, verticalInput);
            }
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimiento al jugador en FixedUpdate para consistencia con fisicas
        rb.linearVelocity = movement * speed;
    }

    void RotatePlayer(float x, float y)
    {
        // Si no hay entrada, no rotar al jugador
        if (x == 0 && y == 0) return;

        // Calcular el angulo de rotacion segun la direccion
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        // Aplicar la rotacion al jugador
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
