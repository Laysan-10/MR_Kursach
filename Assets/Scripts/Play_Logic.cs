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
	public static bool _metod_3 = false;
	List<string> text_for_metod_3 = new List<string>();
	
	[SerializeField] Show_Island _Islans;
	Color _image_color;
	
	   public delegate void MyMethodDelegate(List<string> name); 
	void Method1(){}//сюда заносим метод из другого скрипта
	void Method2(){}

	public void button_click()//Метод считывает нажатие кнопки.
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
			{ 1, _Islans.Show_Logic},//для того чтобы показывать острова и менять текст.
			{ 2, Swipe_text},//для того чтобы только менять текст.
			
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

public void Swipe_text(List<string> name)//метмод под номером 2.
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
void Get_Name(List<string> name)//метод вызывается при нажатие на кнопку, один раз.
{
	_metod_3 = true;
	text_for_metod_3 = name; 
}

   public  void Show_Money_Tree(int i){//метод который вызывается при изменении значения, 
									// в зависимости от int переопределяет список
	
	GameObject _ballon_UI = GameObject.Find("Ballon");
	_image_color = _ballon_UI.GetComponentInParent<Image>().color;
	_ballon_UI.GetComponentInParent<Image>().color = Color.green;
	_ballon_UI.GetComponentInParent<Button>().onClick.AddListener(Image_Color);
	
	if(i == 1)//достаточное кол-во денег
	{
		text_for_metod_3.RemoveAt(0); //удаление элемента текста по индексу, которое не предполагает конвертирование в деньги.
	}
		Swipe_text(text_for_metod_3);//отображение текста,(первый это то что написано в инспекторе.
		_metod_3 = false; //теперь этот метод не вызывается при изменении значений.
   }
   
   void Image_Color(){//возвращает цвет кнопки в исходное.
	GameObject _ballon_UI = GameObject.Find("Ballon");
	_ballon_UI.GetComponentInParent<Image>().color = _image_color;
   }
}
