using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Get_Tree : MonoBehaviour
{
	Transform[] _tree ;//все деревья которые надо скрыть
	[SerializeField]  GameObject _prebaf_tree;//префаб на который заменяются
	GameObject[] _prebaf_mas = new GameObject[100] ;//массив для клонированнфх
	GameObject Parent_Tree;
	[SerializeField] Button _forest;
	Money _skript_money;
	// [SerializeField]GameObject _find;
	// [SerializeField] GameObject _find2;
	int cost = 30;
	public bool check = false;
	GameObject _socket;
	public void Activate_Button(BaseInteractionEventArgs args)//Метод для XRSocketInteractor, SelectEnter
	{ 
		check = true;
		Debug.Log(args);
		Debug.Log(args.interactableObject.transform.gameObject.name);
		
	}
	public  void Non_Activate_Button(BaseInteractionEventArgs args)//Метод для XRSocketInteractor, SelectExit
	 {
	 	check = false;
	 }
	 void Start()
	 {
		_socket = GameObject.Find("XR_Socket");
		_socket.GetComponent<XRSocketInteractor>().selectEntered.AddListener(Activate_Button);
		_socket.GetComponent<XRSocketInteractor>().selectExited.AddListener(Non_Activate_Button);
		_skript_money = FindFirstObjectByType<Money>();
	 		Parent_Tree = GameObject.Find("ALLTREE");
			
			// _find.GetComponent<TextMeshProUGUI>().text = cost.ToString();
			// _find2.GetComponent<TextMeshProUGUI>().text = cost.ToString();
		_tree = Parent_Tree.GetComponentsInChildren<Transform>();
		_forest.enabled = true;
	 }
	public void On_click_forest()//метод для того чтобы можно было
	{	Debug.Log(check);
	if(check)
	{
		Tree_logic(_tree,  _prebaf_tree);// "рубить" деревья
	}						
		
	}
   void Tree_logic(Transform[] Tree, GameObject _prefab)//скрытие объектов
	{
		int i =0;
		_prebaf_mas  =  new GameObject[100];
		foreach(var _tree in Tree)
		{
			if(_tree != null){
			_tree.gameObject.SetActive(false);
			
			GameObject for_mas = Instantiate(_prefab, _tree.transform.position, _tree.transform.rotation);

			_prebaf_mas[i] = for_mas;
			i++;


			}
			
			// Debug.Log("Wait....");
			_forest.GetComponent<Image>().enabled=false;
			StartCoroutine(MyCoroutine());
			


		}
		_skript_money._tree += 10;//получение дерева
		_skript_money.Update_Tree_Ruda();
			
	}

	 IEnumerator MyCoroutine() // Возвращает string
   {

	   yield return new WaitForSeconds(5f);
	   Tree_Del(_tree);
	   _forest.GetComponent<Image>().enabled=true;
   }

	//можно сделать по таймеру
	  void Tree_Del(Transform[] Tree)//удаление ненужных объектов и активация нужных
	{
		int i = 0;
		foreach(var _tree in Tree)
		{
			Destroy(_prebaf_mas[i]);
			if(_tree != null){
			_tree.gameObject.SetActive(true);
			i++;

			}
		}


	}
}
