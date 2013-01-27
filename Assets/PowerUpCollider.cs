using UnityEngine;
using System.Collections;

public class PowerUpCollider : MonoBehaviour {
	
	AudioSource audioSource;
	
	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = false;
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
		MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.enabled = false;
		Destroy(gameObject,7);
		}
	}
	
}
