using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class Balloon_Place : MonoBehaviour
{
	GameObject _socket_for_ballon;
	GameObject _socket_for_ballon_2;
	[SerializeField] GameObject _time_image;
	[SerializeField] GameObject _start_image;
	Plane_Movement _skript_plane_movemant;
	bool _its_end_pos = false; //проверка на то, что это позиция конечная.
	static int i = 0; //фляг начало/конец движения
	Money _money;
	GameObject _ballon;
	bool _was_start = false;
	int give_ruda =0;
	
	XRSocketInteractor _currentsocket;
	
	public void Start_For_Spawn(){
	//активация сокета
		_socket_for_ballon = GameObject.Find("XR_Socket_Ballon_Start");
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_ballon.GetComponent<XRSocketInteractor>().selectEntered.AddListener(Not_End_Pos);//если шар не в конце то ложь
		_skript_plane_movemant = FindFirstObjectByType<Plane_Movement>();
		
			//активация сокета
		_socket_for_ballon_2 = GameObject.Find("XR_Socket_Ballon_End");
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().selectEntered.AddListener(End_Pos);//если шар на конечной точке, то правда.
		
		_start_image = GameObject.Find("START_MOVE_IMG");
		_start_image.GetComponent<Button>().onClick.AddListener(Ballon_Move);//добавляет событие
		 _time_image= GameObject.Find("TIME_IMG");
		_time_image.GetComponent<Image>().enabled = false;
		_money = FindObjectOfType<Money>();
	}
// void OnTriggerEnter(Collider other)
// {
// 	if(other.tag == "Ballon")
// 	{
// 		// _ballon = other.gameObject;
// 		Debug.Log("OnTrigger");
// 		StartCoroutine(Time_Get_Ruda());
// 		// _skript_plane_movemant.move_ballon = false;
// 	}
// }	
	
	IEnumerator Time_Get_Ruda()//действия которые необходимы для
										//визуального сбора ресурсов
	{									//Возможно активация анимаций
										//прекращение движения
	if( i ==1 &&_was_start==true)//Если конец движения
	{
		
		
		_skript_plane_movemant._end.GetComponent<MeshRenderer>().enabled = false;
		// _socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		// _socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		_start_image.GetComponent<Image>().enabled = false;
		_skript_plane_movemant.move_ballon = false;//блокировка движения
		_time_image = GameObject.Find("TIME_IMG");
		_time_image.GetComponent<Image>().enabled = true;//картинка с часами
		Debug.Log("End");
		
		yield return new 	WaitForSeconds(5);
		
		//скрипт Money.
		give_ruda =5;
		
		
		_start_image.GetComponent<Image>().enabled = true;
		_time_image.GetComponent<Image>().enabled = false;
		
	_was_start = false;
	
	}
	if(i == 0 && _was_start == false)//если это начало движения, то по нажатию кнопки активируетсяы
	{
		Debug.Log("Start");
		
			_skript_plane_movemant._end.GetComponent<MeshRenderer>().enabled = false;
		// 	_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		// _socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		_start_image.GetComponent<Image>().enabled = true;//нкопка старт
			_skript_plane_movemant.move_ballon = false;
		_was_start = true;
		_money._ruda+=give_ruda;
		give_ruda =0;_money.Update_Tree_Ruda();
		yield return new 	WaitForSeconds(.5f);
	
	}
	else
	{
		Debug.Log("Have problem in Ballon_Place	");
	}
	}
		
	
	void Ballon_Move()//метод для того чтобы продолжить
	{						//движение машиной с помощью кнопки 
		_skript_plane_movemant._end.GetComponent<MeshRenderer>().enabled = true;
		_start_image.GetComponent<Image>().enabled = false;//нкопка старт
		_currentsocket.enabled = false;
		_skript_plane_movemant.move_ballon = true;//возможность перемедвижения шара
		// _socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = false;
		// _socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = false;
		
		_start_image.GetComponent<Image>().enabled = false;
		
	}
	
	//методы для того чтобы собирать ресурсы с правильного острова
	public void End_Pos(BaseInteractionEventArgs args){
	
		Debug.Log("End_Pos");
		i = 1;
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		_currentsocket = _socket_for_ballon_2.GetComponent<XRSocketInteractor>();
		StartCoroutine(Time_Get_Ruda());
		_was_start = false;
	
	}
	public void Not_End_Pos(BaseInteractionEventArgs args){
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
				Debug.Log("Not_End_Pos");
i = 0;
		_currentsocket = _socket_for_ballon.GetComponent<XRSocketInteractor>();
	StartCoroutine(Time_Get_Ruda());
	_was_start = true;
	
	}
	
	void Start()
	{
		i = 0;
		_was_start = false;
	}
	void Update()
	{
		
	}
}

