using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class arqueraMove : MonoBehaviour
{
	public Transform user;
    private NavMeshAgent enemyAgent;
    private Animator enemyAnimator;

    // Referencia al script PlayerHealth del jugador
    public PlayerHealth playerHealth;

    public float attackRange = 2f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (user != null)
        {
            enemyAgent.destination = user.position;
            enemyAnimator.SetInteger("action", 1);

            // Verificar si el jugador está dentro del rango de ataque
            float distanceToPlayer = Vector3.Distance(transform.position, user.position);
            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                AttackPlayer();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
	{
    // Verificar si el objeto con el que colisionó tiene la etiqueta "Player"
		if (collision.gameObject.CompareTag("Player"))
		{
        // Detener el movimiento del enemigo
			enemyAnimator.SetInteger("action", 2);
			enemyAgent.isStopped = true;

        // Inflictar daño al jugador
			playerHealth.TakeDamage(attackDamage);

        // Mensaje de depuración para confirmar la colisión con el jugador
			Debug.Log("El enemigo colisionó con el jugador.");
		}
	}

    void AttackPlayer()
    {
        // Detener al enemigo
        enemyAgent.isStopped = true;

        // Mirar hacia el jugador
        transform.LookAt(user);

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
	

/*public Transform user;
	private NavMeshAgent enemyAgent;
	public bool UserDetect;
	private Animator enemyAnimator;

    // Start is called before the first frame update
    	void Start()
    	{
		enemyAgent = GetComponent<NavMeshAgent>();
		enemyAnimator = GetComponent<Animator>();
        
    	}

    // Update is called once per frame
    	void Update()
    	{

		if(UserDetect)
		{
			enemyAgent.destination = user.position;
			enemyAnimator.SetInteger("action", 1);
		}
        
    	}

	private void OnCollisionEnter(Collision collision)
    	{
        // Verificar si el objeto con el que colisionó tiene la etiqueta "Mma Kick"
        	if (collision.gameObject.CompareTag("Player"))
        	{
            // Ejecutar la acción deseada, como cambiar la animación o hacer que el personaje se detenga
            	enemyAnimator.SetInteger("action", 2);
            	enemyAgent.isStopped = true; // Detener el movimiento del personaje
        	}
	}*/
