using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Drone_Place : MonoBehaviour
{
	[SerializeField] GameObject _market;
	[SerializeField] GameObject _island;
	
	GameObject _socket_for_drone;
	GameObject _socket_for_drone_2;
	Money _money;
	GameObject _joystic;
	DroneController _controller;
	[SerializeField] UnityEngine.XR.Content.Interaction.XRPushButton  _button;
		[SerializeField] Button _image_end;
	[SerializeField] GameObject _image_start;
	
	bool _was_start = false;
	bool _isend=false;
	int i;
		XRSocketInteractor _current_socket;

  private Vector3 initialPosition; // Начальная позиция дочернего объекта
	private Quaternion initialRotation; // Начальная ориентация дочернего объекта
	private Transform initialParent; // Начальный родитель объекта

	
	   

	// Метод для установки объекта дочерним
	public void SetAsChild()
	{
		// Сделать объект дочерним к родителю
		gameObject.transform.SetParent(_socket_for_drone_2.transform);//становится дочерним к сокету

		// Можно сохранить позицию и вращение в локальных координатах
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
	}

	// Метод для возвращения объекта обратно в мир
	public void ReturnToWorld()
	{
		// Вернуть объект в мир (сохранить его текущие мировые координаты)
		gameObject.transform.SetParent(null);

		// Возвращаем его в начальную позицию и ориентацию
		gameObject.transform.position = initialPosition;
		gameObject.transform.rotation = initialRotation;

		// Можно вернуть исходного родителя
		gameObject.transform.SetParent(initialParent);
	}


public void End_Pos_Dron(BaseInteractionEventArgs args){
	
		
		_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = true;//включение начальной позиции
		droneController.activated = false;
		_image_start.GetComponent<Image>().enabled = true;
		Debug.Log("END");
		// initialPosition = _socket_for_drone_2.transform.position;
		// initialRotation = _socket_for_drone_2.gameObject.transform.rotation;
		// initialParent = gameObject.transform.parent;
	
	}
	public void Not_End_Pos_Drone(BaseInteractionEventArgs args){
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().enabled = true;
		droneController.activated = false;
		Debug.Log("START	");
		
		// initialParent = gameObject.transform.parent;
	
	}
// 	void Not_End_Pos(BaseInteractionEventArgs args){//событие если дрон дошел до конечной точки
// 		_isend=true;
// StartCoroutine(Time_Get_Meat());
// 	}
	
// 	void End_Pos(BaseInteractionEventArgs args){//событие если дрон дошел до стартовой точки
// 		_isend=false;
// StartCoroutine(Time_Get_Meat());
// 	}
	
	
	 void Drone_Move()//метод для того чтобы продолжить
	{						//движение машиной с помощью кнопки 3d и 2d.
		
		
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().enabled = false;
		_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = false;
		droneController.activated = true;//активировать дрон.
			_image_start.GetComponent<Image>().enabled = false;	
		// 	initialPosition = gameObject.transform.position;
		// initialRotation = gameObject.transform.rotation;
		
		
		
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
	
	 void OnEnablee()
	{
		
		_image_start.GetComponent<Image>().enabled = false;
		 SetAsChild();	//объект становится дочерним
			_market.SetActive(true);
		_island.SetActive(false);
		// 	initialPosition = gameObject.transform.position;
		// initialRotation = gameObject.transform.rotation;
	}
	
	void Show_Island()
	{
		ReturnToWorld();//объект не является дочерним
		_image_start.GetComponent<Image>().enabled = false;
		_island.SetActive(true);
		_market.SetActive(false);
		
		 StartCoroutine(Want_EAT());
	
	}

	int _meat = 0;
	bool _was_end = false;
	bool _get_meal = false;
	

	DroneController droneController;
	GameObject _want_meat;
	
	void Start()
	{
		 // Сохраняем начальные значения
		initialPosition = gameObject.transform.position;
		initialRotation = gameObject.transform.rotation;
		initialParent = gameObject.transform.parent;
	
		_want_meat = GameObject.Find("MEAT");//для того чтобы показать что игрок хочет кушать.
		_want_meat.GetComponent<Image>().enabled = false;
		
		_image_start.GetComponent<Button>().onClick.AddListener(OnEnablee);
		_image_end.onClick.AddListener(Show_Island);
		
		droneController = FindObjectOfType<DroneController>();
		
		_socket_for_drone = GameObject.Find("XR_Socket_Drone_Start");
		_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_drone.GetComponent<XRSocketInteractor>().selectEntered.AddListener(Not_End_Pos_Drone);//если шар не в конце то ложь
		
		_controller = FindFirstObjectByType<DroneController>();
		
			//активация сокета
		_socket_for_drone_2 = GameObject.Find("XR_Socket_Drone_End");
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().selectEntered.AddListener(End_Pos_Dron);//если шар на конечной точке, то правда.
		
		
		_image_start.GetComponent<Image>().enabled = false;
	
		_button.onPress.AddListener(Drone_Move);
		
		 StartCoroutine(Want_EAT());
		
	}
	
	
	
void OnTriggerEnter(Collider other)
{
	if(other.tag == "END")
	{
		Debug.Log("OnTriggerEnter");
		_socket_for_drone_2.GetComponent<XRSocketInteractor>().enabled = true;
		_image_start.GetComponent<Image>().enabled = true;
		_was_end = true;
		droneController.activated = false;
		
		if(other.tag == "START"){
				_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = true;
				droneController.activated = false;
		}
	}
}
		
// 	}
	
// 	if(other.tag == "START")
// 	{
// 		if(_was_end == true)
// 		{
// 			_meat =2;
// 		}
// 		_was_end= false;
// 		_socket_for_drone.GetComponent<XRSocketInteractor>().enabled = true;
		
// 	}
	
// 	if(_meat == 2)
// 	{
// 		_meat = 0;
// 		_want_meat.GetComponent<Image>().enabled = false;
// 		 _get_meal = true;
// 		 StartCoroutine(Want_EAT());
// 	}
// }
void OnTriggerExit(Collider other)
{
	// _image_start.GetComponent<Image>().enabled = false;
	Debug.Log("OnTriggerExit");
}


IEnumerator Want_EAT()
{
	_want_meat.GetComponent<Image>().enabled = false;
	yield return new WaitForSeconds(10);
	_want_meat.GetComponent<Image>().enabled = true;
}

	
}
