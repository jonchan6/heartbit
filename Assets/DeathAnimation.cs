using UnityEngine;
using System.Collections;

public class DeathAnimation : MonoBehaviour {

	public float FPS;
	private float secondsToWait;
	public bool Loop;
	public Texture[] frames;
	
	private int currentFrame;
	
	// Use this for initialization
	void Start () 
	{
		currentFrame = 0;
		secondsToWait = 1/FPS;
	}
	
	public IEnumerator Animate()
	{
		bool stop = false;
		
		if(currentFrame >= frames.Length)
		{
			if(Loop == false) {
				stop = true;
				yield return new WaitForSeconds(1.25F);
				Application.LoadLevel (0);
			}
			else
				currentFrame = 0;
		}
		
		yield return new WaitForSeconds(secondsToWait);
		
		renderer.material.mainTexture = frames[currentFrame];
		currentFrame++;
		
		if(stop == false)
			StartCoroutine(Animate());
	}
}