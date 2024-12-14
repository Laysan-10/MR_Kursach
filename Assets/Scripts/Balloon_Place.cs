using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Balloon_Place : MonoBehaviour
{
	GameObject _socket_for_ballon;
	GameObject _socket_for_ballon_2;
	GameObject _time_image;
	GameObject _start_image;
	Plane_Movement _skript_plane_movemant;
	static int i = 0; //фляг начало/конец движения
	
	
	void Start(){
	//активация сокета
		_socket_for_ballon = GameObject.Find("XR_Socket_Ballon_Start");
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		
		_skript_plane_movemant = FindFirstObjectByType<Plane_Movement>();
		
			//активация сокета
		_socket_for_ballon_2 = GameObject.Find("XR_Socket_Ballon_End");
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		
		_start_image = GameObject.Find("START_MOVE_IMG");
		_start_image.GetComponent<Button>().onClick.AddListener(Ballon_Move);//добавляет событие
	}
void OnTriggerEnter(Collider other)
{
	if(other.tag == "Ballon")
	{
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
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = true;
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = true;
		_start_image.GetComponent<Image>().enabled = false;
		_skript_plane_movemant.move_ballon = false;//блокировка движения
		_time_image = GameObject.Find("TIME_IMG");
		_time_image.GetComponent<Image>().enabled = true;//картинка с часами
		yield return new 	WaitForSeconds(5);
		_start_image.GetComponent<Image>().enabled = true;
		_time_image.GetComponent<Image>().enabled = false;
		i = 0;
	
	}
	else//если это начало движения, то по нажатию кнопки активируетсяы
	{
		
		
		_start_image.GetComponent<Image>().enabled = true;//нкопка старт
		
		yield return new 	WaitForSeconds(.5f);
	}
	}
		
	
	void Ballon_Move()//метод для того чтобы продолжить
	{						//движение машиной с помощью кнопки 
		i =1;
		_skript_plane_movemant.move_ballon = true;//возможность перемедвижения шара
		_socket_for_ballon.GetComponent<XRSocketInteractor>().enabled = false;
		_socket_for_ballon_2.GetComponent<XRSocketInteractor>().enabled = false;
		_start_image.GetComponent<Image>().enabled = false;
		
	}
}
