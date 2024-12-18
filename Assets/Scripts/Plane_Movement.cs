

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Plane_Movement : MonoBehaviour
{
	// GameObject xrRayInteractor;
	Vector3 start_pos;
	[SerializeField] XRRayInteractor xrRayInteractor;
	[SerializeField] XRRayInteractor xrRayInteractor_Hand;
	[SerializeField] int _dist;
	 public GameObject _end;
Transform end_pos;
	[SerializeField]
 	[Range(0.1f, 1f)]
	private int max_speed;
	[SerializeField]
	[Range(0.1f, 1f)]
	private int min_speed;
	public bool move_ballon = false;//т.е изначально летательный аппарат не двигается.
 
 
	float speed=0;

	// Start is called before the first frame update

	public void Start()
	{
		move_ballon = false;
		 _end = GameObject.Find("BALLONLOOKAT");//точка за которой следует возд. шар.
		//  xrRayInteractor = GameObject.Find("Ballon_Point");
		//  xrRayInteractor.GetComponent<XRRayInteractor>();

	}

	// Update is called once per frame

	void Update()
	{
		if(xrRayInteractor.enabled == true)
		{
			if(move_ballon){
	_end.gameObject.transform.position = xrRayInteractor.transform.position + xrRayInteractor.transform.forward * 2;
	transform.position=Vector3.MoveTowards(transform.position,_end.gameObject.transform.position,speed/100);
if(Vector3.Distance(transform.position, _end.gameObject.transform.position) >= 10)
{
	speed = Mathf.Lerp(min_speed/10, max_speed/10, 1.5f);
}
	
else{	
	speed = Mathf.Lerp(max_speed / 10, min_speed / 10, 1.5f);
	}}
	
		}
		else
		{
			if(move_ballon){
	_end.gameObject.transform.position = xrRayInteractor_Hand.transform.position + xrRayInteractor_Hand.transform.forward * 2;
	transform.position=Vector3.MoveTowards(transform.position,_end.gameObject.transform.position,speed/100);
if(Vector3.Distance(transform.position, _end.gameObject.transform.position) >= 10)
{
	speed = Mathf.Lerp(min_speed, max_speed, 1.5f);
}
	
else{	
	speed = Mathf.Lerp(max_speed, min_speed, 1.5f);
	}}
	
		}
		}
			
	
}
	
	
	 

	
	

