

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Plane_Movement : MonoBehaviour
{
	// GameObject xrRayInteractor;
	Vector3 start_pos;
	// [SerializeField] GameObject xrRayInteractor;
	// [SerializeField] GameObject xrRayInteractor_Hand;
	
	[SerializeField] int _dist;
	 public GameObject _end;
	public GameObject _end_hand;
Transform end_pos;
	[SerializeField]
 	[Range(1f, 10f)]
	private int max_speed;
	[SerializeField]
	[Range(1f, 10f)]
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
_end_hand = GameObject.Find("BALLONLOOKAT_HAND");
	}



	// Update is called once per frame

	void Update()
	{
		
		if(GameObject.Find("Right Controller") != null)
		{
			if(move_ballon == true){
				_end = GameObject.Find("BALLONLOOKAT");
				Debug.Log("BALOON_MOVE");
	//_end.gameObject.transform.position = xrRayInteractor.transform.position + xrRayInteractor.transform.forward * 2;
	transform.position=Vector3.MoveTowards(transform.position,_end.gameObject.transform.position,speed/1000);
if(Vector3.Distance(transform.position, _end.gameObject.transform.position) >= 10)
{
	speed = Mathf.Lerp(min_speed, max_speed, 2f);
}
	
else{	
	speed = Mathf.Lerp(max_speed, min_speed , 2f);
	}}
	
		}
		else
		{
			if(move_ballon == true){
	//_end.gameObject.transform.position = xrRayInteractor_Hand.transform.position + xrRayInteractor_Hand.transform.forward * 2;
	_end_hand = GameObject.Find("BALLONLOOKAT_HAND");
	
	transform.position=Vector3.MoveTowards(transform.position,_end_hand.transform.position,speed/1000);
if(Vector3.Distance(transform.position, _end_hand.gameObject.transform.position) >= 10)
{
	speed = Mathf.Lerp(min_speed, max_speed, 1.5f);
}
	
else{	
	speed = Mathf.Lerp(max_speed, min_speed, 1.5f);
	}}
	
		}
		}
			
	
}
	
	
	 

	
	

