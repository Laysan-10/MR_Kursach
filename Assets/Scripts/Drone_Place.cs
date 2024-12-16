using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Drone_Place : MonoBehaviour
{
	
	
	GameObject _socket_for_drone;
	GameObject _socket_for_drone_2;
	Money _money;
	GameObject _joystic;
	DroneController _controller;
	[SerializeField] GameObject _time_image;
	[SerializeField] GameObject _start_image;
	bool _isend=false;

	// Start is called before the first frame update
	public void Start_For_Spawn()
	{
		_isend=false;
			_socket_for_drone = GameObject.Find("XR_Socket_Drone_Start");
		_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_drone.GetComponent<XRSocketInteractor>().selectEntered.AddListener(Not_End_Pos);//если шар не в конце то ложь
		_controller = FindFirstObjectByType<DroneController>();
		
			//активация сокета
		_socket_for_drone_2 = GameObject.Find("XR_Socket_Drone_End");
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().selectEntered.AddListener(End_Pos);//если шар на конечной точке, то правда.
		
		_start_image = GameObject.Find("START_MOVE_IMG_DRONE");
		_start_image.GetComponent<Button>().onClick.AddListener(Ballon_Move);//добавляет событие
		//  _time_image= GameObject.Find("TIME_IMG");
		// _time_image.GetComponent<Image>().enabled = false;
		_money = FindObjectOfType<Money>();
	}

	void Not_End_Pos(BaseInteractionEventArgs args){//событие если дрон дошел до конечной точки
		_isend=true;
StartCoroutine(Time_Get_Meat());
	}
	
	void End_Pos(BaseInteractionEventArgs args){//событие если дрон дошел до стартовой точки
		_isend=false;
StartCoroutine(Time_Get_Meat());
	}
	
	void Ballon_Move()//метод для того чтобы продолжить
	{						//движение машиной с помощью кнопки 
		_joystic.GetComponent<MeshRenderer>().enabled = true;
		_start_image.GetComponent<Image>().enabled = false;//нкопка старт
		
		
		_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = false;
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().enabled = false;
		_start_image.GetComponent<Image>().enabled = false;
		
	}
	IEnumerator Time_Get_Meat()
	{
		if(_isend)
		{
			Debug.Log("ISEND");
		}
		else
		{
			Debug.Log("ISSTART");
		}
		yield return new 	WaitForEndOfFrame();
	}
	
}

