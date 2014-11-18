using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour {

	NavMeshAgent agent;

	Vector3 movement;
	float speed = 10f;
	float rotationSpeed = 10f;
	
	Light clickTargetIndicator;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		clickTargetIndicator = FindObjectOfType<GoToClick>().targetIndicator.GetComponent<Light>();
	}
	
	
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		movement.Set(h, 0, v);
		if (h != 0 || v != 0)
		{
			clickTargetIndicator.enabled = false;
			agent.enabled = false;
			transform.rotation = Quaternion.Slerp(
				transform.rotation,
				Quaternion.LookRotation(movement),
				rotationSpeed * Time.deltaTime
			);
			
		}
		Vector3 p2 = transform.position + movement * speed * Time.deltaTime;
		p2.y = 0;
		transform.position = p2;
	}
}
