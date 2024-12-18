using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class basket_logic : MonoBehaviour
{
	Money _money;
	void OnTriggerStay(Collider other)
	{
	
		if(other.tag == "BUY"){
			
			if(other.GetComponent<XRGrabInteractable>().isSelected == false)
			{
				Debug.Log(_money._money );
				if(int.Parse(other.name) <=_money._money  ){
				_money._money = _money._money -  int.Parse(other.name);
				_money.Update_Tree_Ruda();
				Destroy(other.gameObject);
				}
				
			}
			
		}
	}
	void Start(){
	_money = FindObjectOfType<Money>();
	}
}
