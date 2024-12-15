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
void OnTriggerEnter(Collider other)
{
	if(other.tag == "Ballon")
	{
		// _ballon = other.gameObject;
		Debug.Log("OnTrigger");
		StartCoroutine(Time_Get_Ruda());
		// _skript_plane_movemant.move_ballon = false;
	}
}	
	
	IEnumerator Time_Get_Ruda()//действия которые необходимы для
										//визуального сбора ресурсов
	{									//Возможно активация анимаций
										//прекращение движения
	if( i ==1)//Если конец движения
	{
		_skript_plane_movemant._end.GetComponent<MeshRenderer>().enabled = false;
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		_start_image.GetComponent<Image>().enabled = false;
		_skript_plane_movemant.move_ballon = false;//блокировка движения
		_time_image = GameObject.Find("TIME_IMG");
		_time_image.GetComponent<Image>().enabled = true;//картинка с часами
		Debug.Log("End");
		
		yield return new 	WaitForSeconds(5);
		
		//скрипт Money.
		_money._ruda+=5;
		_money.Update_Tree_Ruda();
		
		_start_image.GetComponent<Image>().enabled = true;
		_time_image.GetComponent<Image>().enabled = false;
		i = 0;
	
	
	}
	else//если это начало движения, то по нажатию кнопки активируетсяы
	{
		Debug.Log("Start");
			_skript_plane_movemant._end.GetComponent<MeshRenderer>().enabled = false;
			_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		_start_image.GetComponent<Image>().enabled = true;//нкопка старт
		i = 1;
		yield return new 	WaitForSeconds(.5f);
	
	}
	}
		
	
	void Ballon_Move()//метод для того чтобы продолжить
	{						//движение машиной с помощью кнопки 
		_skript_plane_movemant._end.GetComponent<MeshRenderer>().enabled = true;
		_start_image.GetComponent<Image>().enabled = false;//нкопка старт
		
		_skript_plane_movemant.move_ballon = true;//возможность перемедвижения шара
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = false;
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = false;
		_start_image.GetComponent<Image>().enabled = false;
		
	}
	
	//методы для того чтобы собирать ресурсы с правильного острова
	public void End_Pos(BaseInteractionEventArgs args){
	
		_its_end_pos = true;
		
	
	}
	public void Not_End_Pos(BaseInteractionEventArgs args){
		
		_its_end_pos = false;
		
	
	}
	
}

