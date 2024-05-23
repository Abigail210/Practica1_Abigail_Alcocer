using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DañoDeEnemigo : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    private UnityEngine.AI.NavMeshAgent enemyAgent;
    private Animator enemyAnimator;

    // Referencia al script PlayerHealth del jugador
    public PlayerHealth playerHealth;

    void Start()
    {
        enemyAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de ataque y ha pasado suficiente tiempo desde el último ataque
        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            AttackPlayer();
        }
        else // Si el jugador está fuera del rango de ataque, seguir al jugador
        {
            enemyAgent.SetDestination(player.position);
        }
    }

    void AttackPlayer()
    {
        // Detener al enemigo
        enemyAgent.isStopped = true;

        // Mirar hacia el jugador
        transform.LookAt(player);

        // Ejecutar animación de ataque
        enemyAnimator.SetTrigger("Attack");

        // Inflictar daño al jugador
        playerHealth.TakeDamage(attackDamage);

        // Actualizar el tiempo del último ataque
        lastAttackTime = Time.time;

        // Reiniciar la velocidad del agente después de un corto retraso
        Invoke("ResetAgentSpeed", 0.5f);
    }

    void ResetAgentSpeed()
    {
        enemyAgent.isStopped = false;
    }
}
