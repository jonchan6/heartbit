using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	
	public float FPS;
	private float secondsToWait;
	public bool Loop;
	public Texture[] frames;
	
	private int currentFrame;
	private int counter;
	
	// Use this for initialization
	void Start () 
	{
		counter=0;
		currentFrame = 0;
		secondsToWait = 1/FPS;
		StartCoroutine (Animate ());
	}
	
	public IEnumerator Animate()
	{
		
		AudioSource audiosource = GetComponent<AudioSource>();
		if (counter==20) {
		audiosource.Play();
		counter=0;
		} else {
			counter++;
		}
		
		
		bool stop = false;
		
		if(currentFrame >= frames.Length)
		{
			if(Loop == false) {
				stop = true;
				currentFrame = 0;
			}
			else
				currentFrame = 0;
		}
		
		yield return new WaitForSeconds(secondsToWait);
		
		renderer.material.mainTexture = frames[currentFrame];
		currentFrame++;
		
		if (stop == false)
			StartCoroutine(Animate());
	}
}