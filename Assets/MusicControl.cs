using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {
	
	AudioSource audioSource;
	
	// Use this for initialization
	void Awake () {
		
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = true;
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			if (!audioSource.isPlaying) {
			audioSource.Play ();
			}
		}
	}
	
	void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			if (!audioSource.isPlaying) {
			audioSource.Play ();
			}
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			audioSource.Stop ();
		}
	}
}
