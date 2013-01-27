using UnityEngine;
using System.Collections;

public class wallcollision : MonoBehaviour {
	
	public CharacterController characterController;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		
		playermove player = characterController.GetComponent<playermove>();
		player.SetState (playermove.State.Wall);

	}
	
	void OnTriggerExit(Collider collider)
	{
		
		playermove player = characterController.GetComponent<playermove>();
		player.SetState (playermove.State.Air);
		player.jumpable = true;

	}
	
	
}
