using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverArquera : MonoBehaviour
{
    // Start is called before the first frame update
	
	Rigidbody rb;
		
	Vector2 inMov; //Vector de Movilidad
		
	Vector2 inRot; //Rotacion
		
	Transform cm;
		
	float rX;
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		cm = transform.GetChild(0);
		rX = cm.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        float velocidad = 10f; //Velocidad que tiene al moverse
		inMov.x = Input.GetAxis("Horizontal");
		inMov.y = Input.GetAxis("Vertical");
		inRot.x = Input.GetAxis("Mouse X") * 5; 
		inRot.y = Input.GetAxis("Mouse Y") * 5;
		rb.velocity = transform.forward * velocidad * inMov.y + transform.right * velocidad * inMov.x; //Mover arriba o abajo, izquierda o derecha
		transform.rotation *= Quaternion.Euler(0, inRot.x, 0);//Transformada de rotación, quaternium función para las rotaciones
		rX -= inRot.y;
		rX = Mathf.Clamp(rX, -30, 30);
		cm.localRotation = Quaternion.Euler(rX, 0, 0);
		
    }
}
