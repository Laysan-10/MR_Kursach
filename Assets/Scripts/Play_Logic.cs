using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
[System.Serializable]
public class Person
{
	public int id;//номер метода
	public List<string> name;//фраза
}

public class Play_Logic : MonoBehaviour//связь чисел и методов, для реализации последовательности действий
{ 
	public List<Tuple<int, string>> peopleData; // Исходные данные
	public List<Person> people;                 // Данные для отображения в Unity
	public GameObject textMeshPrefab;           // Префаб для TextMesh
	int i = 0;
	GameObject _text_swipe;
	GameObject _button_swipe;

	
	[SerializeField] Show_Island _Islans;
	
	   public delegate void MyMethodDelegate(List<string> name); 
	void Method1(){}//сюда заносим метод из другого скрипта
	void Method2(){}

	public void button_click()
	{
		if(people[i]!= null)
		{
			InvokeMethod( people[i].id, people[i].name);
		
		i++;
		}
		
		
	}
	private Dictionary<int, MyMethodDelegate> methodDictionary;
 	
	void Start()
	{
		methodDictionary = new Dictionary<int, MyMethodDelegate>()
		{
			{ 1, _Islans.Show_Logic},//если пользователь нажал начать игру
			{ 2, Swipe_text},//если пользователь нажал начать игру
			
		};
		

		
	}

	public void InvokeMethod(int key, List<string> name)
	{
		if (methodDictionary.TryGetValue(key, out MyMethodDelegate method))
		{
			method(name);
		}
		else
		{
			Debug.LogWarning($"Method with key {key} not found.");
		}
	}

public void Swipe_text(List<string> name)
{
	
	_text_swipe= _Islans._textmeshpro;
	_button_swipe = GameObject.Find("House_Button");
	_button_swipe.SetActive(false);	

	StartCoroutine(MyCorutine(name));
	
	
	
}
IEnumerator MyCorutine(List<string> name)
{
	for(int i = 0; i < name.Count -1; i++)
	{
			_text_swipe.GetComponent<TextMeshProUGUI>().text = name[i];
		yield return new WaitForSeconds(5f);
			
	}
			
	_text_swipe.GetComponent<TextMeshProUGUI>().text = name[name.Count-1];
		
	_button_swipe.SetActive(true);
		
	
}
   
}
