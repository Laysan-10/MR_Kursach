

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Plane_Movement : MonoBehaviour
{
	[SerializeField] private XRRayInteractor xrRayInteractor;
	Vector3 start_pos;
	 GameObject _end;
Transform end_pos;
	[SerializeField]
 	[Range(1, 10)]
	private int max_speed;
	[SerializeField]
	[Range(1, 10)]
	private int min_speed;
	public bool move_ballon = false;//т.е изначально летательный аппарат не двигается.
 
 
	float speed=0;

	// Start is called before the first frame update

	void Start()
	{

		 _end = GameObject.Find("BALLONLOOKAT");//точка за которой следует возд. шар.

	}

	// Update is called once per frame

	void Update()
	{
// 		if(move_ballon){
// 	_end.gameObject.transform.position = xrRayInteractor.transform.position + xrRayInteractor.transform.forward * 20;
// 	transform.position=Vector3.MoveTowards(transform.position,_end.gameObject.transform.position,speed/100);
// if(Vector3.Distance(transform.position, _end.gameObject.transform.position) >= 10)
// {
// 	speed = Mathf.Lerp(min_speed, max_speed, 1.5f);
// }
	
// else{	
// 	speed = Mathf.Lerp(max_speed, min_speed, 1.5f);
// 	}}
		
	
}
	
	
	 
}
	
	

