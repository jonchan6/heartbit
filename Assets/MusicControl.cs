using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {
	
	AudioSource audioSource;
	public Camera camera;
	public Camera camera2;
	
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
			if (camera && camera2) {
				camera.enabled = false;
				camera2.enabled = true;
			}
		}
	}
	
	void OnTriggerStay(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			if (!audioSource.isPlaying) {
			audioSource.Play ();
			}
			if (camera && camera2) {
				camera.enabled = false;
				camera2.enabled = true;
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
