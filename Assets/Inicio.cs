using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    [SerializeField] private ControladorJuego controladorJuego;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//Debug.Log("El jugador ha entrado en el área de inicio."); // Mensaje de depuración
			controladorJuego.ActivarTemporizador();
		}
	}
}
