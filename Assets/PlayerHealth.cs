using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image healthProgressBar; // Variable para almacenar la referencia a la ProgressBar

    public float continuousDamagePerSecond = 1f; // Daño continuo por segundo

    void Start()
    {
        currentHealth = maxHealth;

        // Asegurar que healthProgressBar esté inicializado antes de actualizar la ProgressBar
        if (healthProgressBar != null)
        {
            UpdateHealthProgressBar(); // Llama a esta función para actualizar la ProgressBar al inicio del juego
        }
        else
        {
            Debug.LogError("La referencia a healthProgressBar no está asignada en el Inspector.");
        }
    }

    void Update()
    {
        // Reducir la salud del jugador con el tiempo
        TakeDamageOverTime(continuousDamagePerSecond * Time.deltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }

        // Actualizar el valor de la ProgressBar
        UpdateHealthProgressBar();
    }

    void Die()
    {
        // Aquí puedes implementar lógica para cuando el jugador muere,
        // como reiniciar la escena o mostrar un mensaje de Game Over.
        Debug.Log("Player has died!");
    }

    void UpdateHealthProgressBar()
    {
        // Actualizar el valor de la ProgressBar basado en la salud actual del jugador
        healthProgressBar.fillAmount = (float)currentHealth / maxHealth;
    }

    void TakeDamageOverTime(float damage)
    {
        int damageAmount = Mathf.RoundToInt(damage); // Conversión explícita de float a int
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }

        // Actualizar el valor de la ProgressBar después de recibir daño
        UpdateHealthProgressBar();
    }
}
