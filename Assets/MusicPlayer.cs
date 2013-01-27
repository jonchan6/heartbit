using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		Debug.Log ("LOGGING");
		Debug.Log (audioSource.audio);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
		
	void OnTriggerEnter(Collider otherCollider)
	{
	}
	
	/**
	 * OnTriggerExit is called when one collider exits the volume of another collider.
	 */
	void OnTriggerExit(Collider otherCollider)
	{
	}
	
	/**
	 * OnTriggerStay is called when on collider is inside the volume of another collider.
	 */
	void OnTriggerStay(Collider otherCollider)
	{
	}
}
