using UnityEngine;
using System.Collections;

public class GoToClick : MonoBehaviour {

	public Transform targetIndicator;
	NavMeshAgent agent;
	
	int layerMask;
	float cameraRayDepth = 100f;

	
	void Awake () {
		agent = GetComponent<NavMeshAgent> ();
		layerMask = LayerMask.GetMask("Ground");
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			agent.enabled = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, cameraRayDepth, layerMask))
			{
				targetIndicator.position = new Vector3(
					hit.point.x,
					targetIndicator.position.y,
					hit.point.z
				);
				
				agent.SetDestination(hit.point);
			}
		}
	}
}
