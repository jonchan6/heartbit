using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
	
	public CharacterController characterController;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onTriggerEnter(Collider collider)
	{
			
	}
	
	void onTriggerStay(Collider collider)
	{
			
	}
		/* this is for colliding with a weapon from player
		if (collider.gameObject.GetComponent<?hook or donkeykong arm?>()) {
			// if touch player do something
			}
		}
		*/
}
