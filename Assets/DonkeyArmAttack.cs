using UnityEngine;
using System.Collections;

public class DonkeyArmAttack : MonoBehaviour {
	
	public CharacterController characterController;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onTriggerEnter(Collider collider)
	{
		Debug.Log (" on trigger enter encountered");
		playermove player = characterController.GetComponent<playermove>();
		if (player.donkeykongattack) {
			Destroy (gameObject, 0.5F);
		}
	}
	
	
	void onTriggerStay(Collider collider)
	{
		Debug.Log (" on trigger stay encountered");
		playermove player = characterController.GetComponent<playermove>();
		if (player.donkeykongattack) {
			Destroy (gameObject, 0.5F);
		}
			
	}
		/* this is for colliding with a weapon from player
		if (collider.gameObject.GetComponent<?hook or donkeykong arm?>()) {
			// if touch player do something
			}
		}
		*/

}
