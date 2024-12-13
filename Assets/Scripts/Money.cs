using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

public class Money : MonoBehaviour//логика которая отвечает за покупки и
{     							//за конвертирование ресурсов в деньги
	public int _cost; //Цена за товар.
	int _money = 40; //Кол-во денер.
	public int _tree;// Кол-во дерева.
	int _ruda; //Кол-во камня/руды	
	 //Области для записи значения кол-ва цены.
	[SerializeField]GameObject _find;
	[SerializeField] GameObject _find2;
	[SerializeField] GameObject _find3;
	[SerializeField] GameObject _find4;
	GameObject _ob;
	
	void Start()
	{
		//Запись значений цены в соот. поля.
		_find.GetComponent<TextMeshProUGUI>().text = _money.ToString();
			_find2.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	}		  
public void Button_Cost(GameObject _button)//для покупки ресурсов
{
	_cost = Convert.ToInt32(_button.name);//имя кнопки это цена
	if(_money >= _cost){
		_money-=_cost;//логическое измененние цены
		//визуальное изменение цены
		_find.GetComponent<TextMeshProUGUI>().text = _money.ToString();
		_find2.GetComponent<TextMeshProUGUI>().text = _money.ToString();
		_find3.GetComponent<TextMeshProUGUI>().text = _tree.ToString();
		_find4.GetComponent<TextMeshProUGUI>().text = _ruda.ToString();
		Spawn(_button.	transform.GetChild(0));
	}
}
void Spawn(Transform _spawn){//метод для клонирования объектов
Debug.Log(_spawn.name);
_ob = Instantiate(_spawn.gameObject, transform.position + new Vector3(0, 0, 0), _spawn.gameObject.transform.rotation);
}
public void Convetr_Tree(){
	_money += 1;
	_tree -= 5;
	_find.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	_find2.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	_find3.GetComponent<TextMeshProUGUI>().text = _tree.ToString();
}

public void Convetr_Ruda(){
	_money += 3;
	_ruda -= 5;
	_find.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	_find2.GetComponent<TextMeshProUGUI>().text = _money.ToString();
	_find4.GetComponent<TextMeshProUGUI>().text = _ruda.ToString();
}
}
