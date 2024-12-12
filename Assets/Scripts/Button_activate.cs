using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_activate : MonoBehaviour
{
	[SerializeField]  GameObject[] _tree = new GameObject[100];//все деревья которые надо скрыть
	[SerializeField]  GameObject _prebaf_tree;//префаб на который заменяются 
	[SerializeField] GameObject[] _prebaf_mas ;//массив для клонированнфх
	int cost = 0;
	
	public void Button()
	{
		Tree_logic(_tree, _prebaf_tree);//скрытие объектов
	}
	
	public void Tree_logic(GameObject[] Tree, GameObject _prefab)//скрытие объектов
	{
		int i =0;
		_prebaf_mas  = new GameObject[Tree.Length];
		foreach(var _tree in Tree)
		{
			if(_tree != null){
			_tree.SetActive(false);
			cost += 10;//тип получаем деньги за вырубку
			GameObject for_mas = Instantiate(_prefab, _tree.transform.position, _tree.transform.rotation);
			
			_prebaf_mas[i] = for_mas;
			i++;
			Debug.Log("Wait....");
			StartCoroutine(MyCoroutine(3f));
			
			}
		}
	}
	
	 IEnumerator MyCoroutine(float time)
	{
		yield return new WaitForSeconds(time);
		Tree_Del(_tree);
		
	}
	
	
	
	
	//можно сделать по таймеру
	 public void Tree_Del(GameObject[] Tree)//удаление ненужных объектов и активация нужных
	{
		int i = 0;
		foreach(var _tree in Tree)
		{
			Destroy(_prebaf_mas[i]);
			if(_tree != null){
			_tree.SetActive(true);
			i++;
			
			}
		}
		
		
}}
