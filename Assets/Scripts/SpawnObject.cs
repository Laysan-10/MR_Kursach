using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SpawnObject : MonoBehaviour
{
	GameObject _ob;
	public Vector3 x;
	public int y;
	GameObject _xr;
	[SerializeField] Money _money;
	
	bool spawn_ballon_once = true;
	bool spawn_drone_once = true;
	
	bool check = false;
	bool can_buy_rope = true;
	[SerializeField] XRSocketInteractor socketInteractor;

	public void Spawn(GameObject _obj)
	{
		if(Money.can_buy && can_buy_rope)
{
		_ob = Instantiate(_obj, transform.position + new Vector3(0, 0, 0), _obj.transform.rotation);
		check = true;
		Money.can_buy = false;
		can_buy_rope = false;
}
	}

	
	public void Socket(GameObject _object)
	{
		_object.transform.position = transform.position;
	}
public void Invoke_Gameobject(GameObject _onscene){
	Debug.Log("Money.can_buy"+Money.can_buy);
// _onscene.SetActive(true);	
if(Money.can_buy)
{
	
	if(_onscene.name == "air_balloon_red" && GameObject.Find("Snow") == true && spawn_ballon_once)
{
	_money._money-=40;
	Debug.Log("air_balloon_red");
	_onscene.SetActive(true);
	GameObject.Find("XR_Socket_Ballon_Start").GetComponent<MeshRenderer>().enabled = true;
	GameObject.Find("XR_Socket_Ballon_End").GetComponent<MeshRenderer>().enabled = true;
	
	GameObject.Find("XR_Socket_Ballon_Start").GetComponent<Balloon_Place>().Start_For_Spawn();
	GameObject.Find("XR_Socket_Ballon_End").GetComponent<Balloon_Place>().Start_For_Spawn();
	
}
if(_onscene.name == "DRONE" && GameObject.Find("Shop") == true && spawn_drone_once)
{_money._money-=60;
	_onscene.SetActive(true);
	GameObject.Find("XR_Socket_Drone_Start").GetComponent<MeshRenderer>().enabled = true;
	GameObject.Find("XR_Socket_Drone_End").GetComponent<MeshRenderer>().enabled = true;
	
	// GameObject.Find("XR_Socket_Drone_Start").GetComponent<Drone_Place>().Start_For_Spawn();
	// GameObject.Find("XR_Socket_Drone_End").GetComponent<Drone_Place>().Start_For_Spawn();
	
}
Money.can_buy = false;
}


}
 
 void Start()
 {
 	 spawn_ballon_once = true;
	 spawn_drone_once = true;
	 
 }

	// private void OnEnable()
	// {
	// 	socketInteractor.selectEntered.AddListener(OnSelectEntered);
	// }

	// private void OnDisable()
	// {
	// 	socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
	// }

	// private void OnSelectEntered(SelectEnterEventArgs args)
	// {
	// 	Debug.Log("Object selected and entered the socket: " + args);
	// 	// Ваш код здесь
	// }
}
