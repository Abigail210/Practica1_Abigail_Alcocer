using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    [SerializeField] private ControladorJuego controladorJuego;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			controladorJuego.DesactivarTemporizador();
		}
	}
}
