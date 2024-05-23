using System.Collections;
using System.Collections.Generic;
/*using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 50f; // Velocidad de movimiento

    public CharacterController Controlador;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
	// Obtener la entrada del teclado
        float x = Input.GetAxis("Horizontal");//Eje x
        float z = Input.GetAxis("Vertical"); //Eje z

	//Vector3 mover = transform.right * x + transform.forward * z;

	//Controlador.Move(mover);

	 Vector3 mover = new Vector3(x, 0f, z);
        mover = mover.normalized * velocidad * Time.deltaTime;

        // Mover el objeto usando el Transform
        transform.Translate(mover * velocidad * Time.deltaTime);


    }
}*/

using UnityEngine;

public class MovimientoYRotacion : MonoBehaviour
{
    public float velocidadRotacion = 5f; // Velocidad de rotación
    public float velocidadMovimiento = 5f; // Velocidad de movimiento

    private float rotacionAcumulada = 0f;
    private float alturaAcumulada = 0f;

    void Update()
    {
        // Rotación 360 grados
        Rotar(360f);

        // Movimiento hacia arriba
        MoverArriba();

        // Rotación 360 grados
        Rotar(360f);

        // Movimiento hacia abajo
        MoverAbajo();

        // Rotación 360 grados
        Rotar(360f);
    }

    void Rotar(float grados)
    {
        float rotacionPorFrame = velocidadRotacion * Time.deltaTime;

        // Calcular la rotación acumulada
        rotacionAcumulada += rotacionPorFrame;

        // Limitar la rotación acumulada a los grados especificados
        rotacionAcumulada = Mathf.Repeat(rotacionAcumulada, grados);

        // Aplicar la rotación acumulada al objeto
        transform.rotation = Quaternion.Euler(0f, rotacionAcumulada, 0f);
    }

    void MoverArriba()
    {
        float movimientoPorFrame = velocidadMovimiento * Time.deltaTime;

        // Mover hacia arriba
        transform.Translate(Vector3.up * movimientoPorFrame);

        // Rastrear la altura acumulada
        alturaAcumulada += movimientoPorFrame;
    }

    void MoverAbajo()
    {
        float movimientoPorFrame = velocidadMovimiento * Time.deltaTime;

        // Mover hacia abajo
        transform.Translate(Vector3.down * movimientoPorFrame);

        // Rastrear la altura acumulada
        alturaAcumulada += movimientoPorFrame;
    }
}


