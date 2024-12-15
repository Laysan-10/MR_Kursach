using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SpawnObject : MonoBehaviour
{
	GameObject _ob;
	public Vector3 x;
	public int y;
	GameObject _xr;
	
	bool check = false;
	[SerializeField] XRSocketInteractor socketInteractor;

	public void Spawn(GameObject _obj)
	{
		_ob = Instantiate(_obj, transform.position + new Vector3(0, 0, 0), _obj.transform.rotation);
		check = true;
	}

	
	public void Socket(GameObject _object)
	{
		_object.transform.position = transform.position;
	}
public void Invoke_Gameobject(GameObject _onscene){
	
_onscene.SetActive(true);

if(_onscene.name == "air_balloon_red" && GameObject.Find("Snow") == true)
{
	GameObject.Find("XR_Socket_Ballon_Start").GetComponent<MeshRenderer>().enabled = true;
	GameObject.Find("XR_Socket_Ballon_End").GetComponent<MeshRenderer>().enabled = true;
	
	GameObject.Find("XR_Socket_Ballon_Start").GetComponent<Balloon_Place>().Start_For_Spawn();
	GameObject.Find("XR_Socket_Ballon_End").GetComponent<Balloon_Place>().Start_For_Spawn();
	
}

}
 

	// private void OnEnable()
	// {
	// 	socketInteractor.selectEntered.AddListener(OnSelectEntered);
	// }

	// private void OnDisable()
	// {
	// 	socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
	// }

	// private void OnSelectEntered(SelectEnterEventArgs args)
	// {
	// 	Debug.Log("Object selected and entered the socket: " + args);
	// 	// Ваш код здесь
	// }
}
