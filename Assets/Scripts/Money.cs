using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

public class Money : MonoBehaviour//логика которая отвечает за покупки и
{     							//за конвертирование ресурсов в деньги
	public int _cost;//Цена за товар.
	public int _money;
	public int _tree;
	public int _Money 
	{
		get{return _money;}
		set
		{
			_money = value;
			Debug.Log("Update_Money");
			Update_Tree_Ruda();
			if(Play_Logic._metod_3)
			{
				_play_logic.Show_Money_Tree(1);
			}//вызывает метод, которое вызывает событие при опр цене.
			
		}
		
	} //Кол-во денер.
	public int _Tree
	{
		get{return _tree;}
		set
		{
			_tree = value;
			Debug.Log("Update_Tree");
			
				Update_Tree_Ruda();
			if(Play_Logic._metod_3)
			{
				_play_logic.Show_Money_Tree(0);
			}//вызывает метод, которое вызывает событие при опр цене.
			
		}
	}// Кол-во дерева.
	public int _ruda=0; //Кол-во камня/руды	
	 //Области для записи значения кол-ва цены.
	[SerializeField]GameObject _find;
	[SerializeField] GameObject _find2;
	[SerializeField] GameObject _find3;
	[SerializeField] GameObject _find4;
	GameObject _ob;
	Play_Logic _play_logic;
	
	void Start()
	{
		_money = 40;
		_tree = 0;
		//Запись значений цены в соот. поля.
		Update_Tree_Ruda();
		
	}		  
public void Button_Cost(GameObject _button)//для покупки ресурсов.
{
	_cost = Convert.ToInt32(_button.name);//имя кнопки это цена.
	if(_money >= _cost){
		_money-=_cost;//логическое измененние цены.
		//визуальное изменение цены.
		Update_Tree_Ruda();
		Spawn(_button.	transform.GetChild(0));
	}
}
void Spawn(Transform _spawn){//метод для клонирования объектов.
Debug.Log(_spawn.name);
_ob = Instantiate(_spawn.gameObject, transform.position + new Vector3(0, 0, 0), _spawn.gameObject.transform.rotation);
}
public void Convetr_Tree(){
	if(_tree >= 5)
	{
		_money += 1;
	_tree -= 5;
Update_Tree_Ruda();
	}
	
}

public void Convetr_Ruda(){
	if(_ruda >=5)
	{
		_money += 3;
	_ruda -= 5;
	Update_Tree_Ruda();
	}
	
}

public void Update_Tree_Ruda()//для того чтобы обновлять инфу о кол-ве ресурсов.
{
	_find.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	_find2.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	_find3.GetComponent<TextMeshProUGUI>().text = _tree.ToString();
	_find4.GetComponent<TextMeshProUGUI>().text = _ruda.ToString();
}


}
