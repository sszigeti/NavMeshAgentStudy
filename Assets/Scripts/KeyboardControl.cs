using UnityEngine;
using System.Collections;

public class KeyboardControl : MonoBehaviour {

	NavMeshAgent agent;

	Vector3 movement;
	float speed = 10f;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		movement.Set(h, 0, v);
		if (h != 0 || v != 0)
		{
			agent.enabled = false;
			transform.rotation = Quaternion.LookRotation(movement);
			
		}
		Vector3 p2 = transform.position + movement * speed * Time.deltaTime;
		p2.y = 0;
		transform.position = p2;
	}
}
