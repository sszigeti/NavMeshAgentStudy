using UnityEngine;
using System.Collections;

public class Pursue : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	
	void Awake () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update () {
		agent.SetDestination(target.position);
	}
}
