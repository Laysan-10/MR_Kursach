using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible_UnVisible : MonoBehaviour
{
   void  OnTriggerEnter(Collider other)
   {
	Debug.Log("Ontriggerstay");
	Debug.Log(other.name);
	
	// if(other.tag == "UI")
	// {
		other.enabled = false;
	// }
   }
   
   void  OnTriggerExit(Collider other)
   {
	Debug.Log("Ontriggerexit");
	
	if(other.tag == "UI")
	{
		other.enabled = true;
	}
   }
}
