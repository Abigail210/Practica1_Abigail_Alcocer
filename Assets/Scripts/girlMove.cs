using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class girlMove : MonoBehaviour
{

	public Transform user;
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
			enemyAnimator.SetInteger("action2", 1);
		}
        
    	}
}