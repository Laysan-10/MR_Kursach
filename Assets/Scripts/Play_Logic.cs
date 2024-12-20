using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
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
	List<GameObject> _image_rotation = new List<GameObject>();
	[SerializeField] Show_Island _Islans;
	Color _image_color;
	Camera _main;
	[SerializeField] AudioClip _click;
	[SerializeField] AudioClip _hover;
	[SerializeField] AudioSource _play_audio;
	[SerializeField] Slider _click_slider;

	Button _button_click;
	private EventTrigger eventTrigger;
	
	[SerializeField] GameObject _ballon_UI;
	   public delegate void MyMethodDelegate(List<string> name); 
	void Method1(){}//сюда заносим метод из другого скрипта
	void Method2(){}
	void Method3(){}

	public void button_click()//Метод считывает нажатие кнопки.
	{
		if(people.Count > i)
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
			{3, Get_Name},
			
		};
		   Image[] allImages = FindObjectsOfType<Image>();
		   TMP_Text[] alltext = FindObjectsOfType<TMP_Text>();
		   Button[] allbutton = FindObjectsOfType<Button>();
		
		foreach (Image img in allImages)
		{
			 _image_rotation .Add(img.gameObject);
			 
		}
		foreach(Button but in allbutton)
		{
			but.onClick.AddListener(Click);
			
		}
		
		
		
		foreach (TMP_Text img in alltext)
		{
			 _image_rotation .Add(img.gameObject);
		}
		_main = FindObjectOfType<Camera>();
	}
	 public void OnPointerEnter(PointerEventData eventData)
	{
		// Call your Hover method or perform actions on hover
		Hover();
	}
	 void Click(){
		_play_audio.PlayOneShot(_click);
	 }
	 void Hover(){
		_play_audio.PlayOneShot(_hover);
	 }
	
	void Update(){
		foreach (var img in _image_rotation)
		{
			 img.transform.LookAt(_main.transform);
			 img.transform.rotation = Quaternion.Euler(
			img.transform.rotation.eulerAngles.x,
			img.transform.rotation.eulerAngles.y + 180,
			img.transform.rotation.eulerAngles.z);

		}
		_play_audio.volume = _click_slider.value;
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
	_button_swipe.GetComponent<Image>().enabled = false;	

	StartCoroutine(MyCorutine(name));
}
IEnumerator MyCorutine(List<string> name)
{
	for(int i = 0; i < name.Count -1; i++)
	{
			_text_swipe.GetComponent<TextMeshProUGUI>().text = name[i];
		yield return new WaitForSeconds(.5f);
			
	}
			
	_text_swipe.GetComponent<TextMeshProUGUI>().text = name[name.Count-1];
		
	_button_swipe.GetComponent<Image>().enabled = true;	
		
	
}
void Get_Name(List<string> name)//метод вызывается при нажатие на кнопку, один раз.
{
	_metod_3 = true;
	text_for_metod_3 = name; 
	_button_swipe.GetComponent<Image>().enabled = false;	
}



bool was_metod = false;

   public  void Show_Money_Tree(int i){//метод который вызывается при изменении значения, 
									// в зависимости от int переопределяет список
	if(was_metod == false)
	{
		_image_color = _ballon_UI.GetComponent<Image>().color;
	_ballon_UI.GetComponent<Image>().color = Color.green;
	_ballon_UI.GetComponent<Button>().onClick.AddListener(Image_Color);
	
	if(i == 1)//достаточное кол-во денег
	{
		text_for_metod_3.RemoveAt(0); //удаление элемента текста по индексу, которое не предполагает конвертирование в деньги.
		Swipe_text(text_for_metod_3);//отображение текста,(первый это то что написано в инспекторе.
		_metod_3 = false; //теперь этот метод не вызывается при изменении значений.
		was_metod = true;//для того чтобы вызывася этот метод один раз
	}
	if(i == 0)
	{
		text_for_metod_3.RemoveAt(1);
		Swipe_text(text_for_metod_3);
	}
	
	}
	
		
   }
   
   void Image_Color(){//возвращает цвет кнопки в исходное.
	_ballon_UI.GetComponent<Image>().color = _image_color;
	Debug.Log("Spawn_BalLon");
   }
}
