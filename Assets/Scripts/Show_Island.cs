
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Show_Island : MonoBehaviour//прописать логику диалогов и появления островов
{
	[SerializeField] List<GameObject> gameObjects_island = new List<GameObject>();
	 
	
	public 	GameObject _textmeshpro;
	public GameObject _button;
	

	
	GameObject _human;
 int _island_index = 1;
	
	public delegate void sh_island(string name); //делегат который содержит ссылка на методы
	void Method1(){}//сюда заносим метод из другого скрипта
	void Method2() {  }
	void Method3() { }


	private  Dictionary<int, sh_island> All_Island;

	void Start()
	{
		All_Island = new Dictionary<int, sh_island>()
		{
			{ 1, House},
			{ 2,  Forest},//заполнить все массивы который, вызываются последовательно

			{ 3, Sand_city },
			{ 4, Sand_city },
			{ 5, City },

		};



		// foreach (var child in _tree)//скрывает все элементы
		// {
		// 	 if (child != Parent_Tree.transform) // Пропускаем родительский объект
		//         {
		//             child.gameObject.SetActive(false);
		//         }
		// }






	}



	public  void Show_Logic(List<string> name)//что-то типа консткуртора, который распеделяет на разные методы
	 {

		//индекс острова, для вызова методы
		Debug.Log(_island_index);
		foreach(var g in gameObjects_island){
			Debug.Log(g.name);
		}

		if (All_Island.TryGetValue(_island_index, out sh_island method))//вызов метода
		{
			method(name[0]);


		}
		else//проверка
		{
			Debug.LogWarning($"Method with key {_island_index} not found.");
		}
		_island_index +=1;
		

	}
	public void House(string name)//когда пользователь нажимает на начать, то появляется остров и остальная логика для показа ui
	{
		
		gameObjects_island[_island_index -1].gameObject.SetActive(true);//активирует отображение острова
		//логика персонажа, возможно передача идекса массива для того чтобы правильно выбирать фразы т.е метод
		//включить звуки и анимацию
		_textmeshpro = GameObject.Find("House_Text");
		_textmeshpro.GetComponent<TextMeshProUGUI>().text = name ;//отображение текста, который написан в инспекторе
		// Debug.Log(_textmeshpro.GetComponent<TextMeshProUGUI>());//проверка наличия компонента
		_human = GameObject.Find("House_Human");
		_human.GetComponent<Animator>().Play("Talk");
		_button = GameObject.Find("House_Button");
		_button.GetComponent<Image>().enabled = true;//отображение кнопки, для чтения текста
		// _button.SetActive(true);
		
	}
	
	
	public void Forest(string name)//реализция логики получения денег
	{
			Debug.Log("Forest()");
		gameObjects_island[_island_index-1].gameObject.SetActive(true);//отображение острова
		// _textmeshpro.transform.position = gameObjects_island[_island_index-1].transform.position + new Vector3(0, 50, 0);
		// _button.transform.position = _textmeshpro.transform.position + new Vector3(24, -6, 18);
		// //реализация роста деревьев
_textmeshpro.GetComponent<TextMeshProUGUI>().text = name ;

	
		
	}
	
	void City(string name)
	{
		gameObjects_island[_island_index-1].gameObject.SetActive(true);
	}


	void Sand_city(string name)
	{
		gameObjects_island[_island_index-1].gameObject.SetActive(true);
	}

	public void Snow_city(string name)
	{
	gameObjects_island[_island_index-1].gameObject.SetActive(true);
	}

	//вырука лесов, надо добавить доп метод, для кнопки

	
}

