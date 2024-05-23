using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
	public Transform[] views;
	public float transitionSpeed;
	Transform currentView;

// Start is called before the first frame update
	void Start()
	{

		currentView = transform;
	
	}

    // Update is called once per frame
	void Update()
	{

		if(Input.GetKeyDown(KeyCode.O))
		{
			currentView = views[0];
		}
		if(Input.GetKeyDown(KeyCode.B))
		{
			currentView = views[1];
		}
		if(Input.GetKeyDown(KeyCode.C))
		{
			currentView = views[2];
		}
	}

	private void LateUpdate()
	{
		transform.position = Vector3.Lerp(transform.position,currentView.position,Time.deltaTime * transitionSpeed);
	
		Vector3 currentAngle = new Vector3(
			Mathf.Lerp(transform.rotation.eulerAngles.x,currentView.transform.rotation.eulerAngles.x,Time.deltaTime*transitionSpeed),
			Mathf.Lerp(transform.rotation.eulerAngles.y,currentView.transform.rotation.eulerAngles.y,Time.deltaTime*transitionSpeed),
			Mathf.Lerp(transform.rotation.eulerAngles.z,currentView.transform.rotation.eulerAngles.z,Time.deltaTime*transitionSpeed));

		transform.eulerAngles = currentAngle;
	}

 
}
