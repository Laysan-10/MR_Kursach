

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Plane_Movement : MonoBehaviour
{
	[SerializeField] private XRRayInteractor xrRayInteractor;
	Vector3 start_pos;
	[SerializeField] Transform _end;
Transform end_pos;
	[SerializeField]
 	[Range(1, 10)]
	private int max_speed;
	[SerializeField]
	[Range(1, 10)]
	private int min_speed;
 
 
	float speed=0;

	// Start is called before the first frame update

	void Start()
	{

		 

	}

	// Update is called once per frame

	void Update()
	{
		_end.position = xrRayInteractor.transform.position + xrRayInteractor.transform.forward * 20;
	transform.position=Vector3.MoveTowards(transform.position,_end.position,speed/100);
if(Vector3.Distance(transform.position, _end.position) >= 10)
{
	speed = Mathf.Lerp(min_speed, max_speed, 1.5f);
}
	
else{	
	speed = Mathf.Lerp(max_speed, min_speed, 1.5f);
	}
	
}
	
	
	 
}
	
	

