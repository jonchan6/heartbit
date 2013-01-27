using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {
	
	/*
	public float moveForce;
	public float jumpForce;
	
	void FixedUpdate()
	{
		Vector3 input = Input.GetAxisRaw("Horizontal") * Vector3.right;
		rigidbody.AddForce(input * moveForce * Time.deltaTime, ForceMode.Acceleration);
	}
	
	void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
		}
	}
	*/
	
	public float moveSpeed;
	public float jumpForce;
	public float gravity;
	private CharacterController characterController;
	private Animation animation;
	private MarioAnimation marioAnimation;
	private Vector3 velocity;
	public bool jumpable = true;
	public bool controlLock = false;
	
	public bool sonic = false;
	public bool link = false;
	public bool donkeykongarm = false;
	public bool donkeykongattack = false;
	public float donkeykongattackcooldown = 3;
	public bool mario = false;
	
	
	public enum State
	{
		Idle,
		Jump,
		Wall,
		Air,
	}
	
	public State state;
	
	public void SetState(State newState)
	{
		switch (newState)
		{
		case State.Idle:
			
			if (mario) {
			//animation.Loop=false;
			//marioAnimation.StartCoroutine(marioAnimation.Animate());
			}
			else if (donkeykongarm) {
			}
			else if (sonic) {
			}
			else {
			animation.Loop=true;
			animation.StartCoroutine(animation.Animate());
			}
			if (state == State.Jump)
			{
				
			}
			break;
			
		case State.Jump:
			velocity = jumpForce * Vector3.up;
			
			// play animation
			break;
		
		case State.Wall:
			break;
			
		case State.Air:
			break;
		}
	
		state = newState;
	}
	
	void Awake()
	{
		controlLock = false;
		characterController = GetComponent<CharacterController>();
		animation = GetComponentInChildren<Animation>();
		marioAnimation = GetComponentInChildren<MarioAnimation>();
	}
	
	void KillHeart() 
	{
		animation.Loop=false;
		//marioAnimation.Loop=false;
		controlLock = true;
		DeathAnimation deathAnimation = GetComponentInChildren<DeathAnimation>();
		deathAnimation.StartCoroutine(deathAnimation.Animate());
	}
	
	private IEnumerator ResumeAfterSeconds(int resumetime)
	{
		yield return new WaitForSeconds(3);
	}
	
	void OnTriggerEnter(Collider collider) 
	{
		if (collider.gameObject.tag == "Spike") {
			KillHeart();
		}
		else if (collider.gameObject.tag == "SonicShoes") {
			if (sonic == false) {
			sonic = true;
			moveSpeed += 7;
			}
		}
		else if (collider.gameObject.tag == "MarioHat") {
			if (mario == false) {
			mario = true;
			
			Debug.Log (transform.localScale.ToString());
			Debug.Log (transform.position.ToString());
			
			transform.Translate(new Vector3(0,2.8F,0));
			transform.GetChild (0).transform.localScale = new Vector3(2.0F,0.2F,1.0F);
			transform.GetChild (1).transform.localScale = new Vector3(1.0F,2.0F,2.0F);
			transform.GetChild (2).transform.localScale = new Vector3(1.0F,1.0F,1.0F);
			characterController.radius = 0.5F;
			characterController.height = 2.0F;		
			}
		}
		
		else if (collider.gameObject.tag == "DonkeyPunch") {
			if (donkeykongarm == false) {
				donkeykongarm = true;
			}
		}
		else if (collider.gameObject.tag == "Monster") {
			KillHeart();
		}
	}
	
	void Update()
	{
		
		if (transform.position.y < -25) {
			KillHeart ();
		}
		
		if (controlLock) {
			return;
		}
		Vector3 move = Input.GetAxisRaw("Horizontal") * Vector3.right;
		
		move *= moveSpeed * Time.deltaTime;
		
		
		velocity += gravity * Vector3.up * Time.deltaTime;
		
		if (characterController.isGrounded)
		{
			if (state != State.Idle)
				SetState(State.Idle);
			
			velocity = gravity * Vector3.up * Time.deltaTime;
		
			if (Input.GetButtonDown ("Jump"))
			{
				animation.Loop=false;
				SetState(State.Jump);
			}	
		}
		
		if (Input.GetButtonDown ("Jump"))
			{
				if (state == State.Wall && jumpable) {
					SetState(State.Jump);
					jumpable = false;
				}
			}
		
		move += velocity * Time.deltaTime;
		
		characterController.Move(move);
		
		if (Input.GetButtonDown ("Fire1")) {
			if (donkeykongattack == false) {
				donkeykongattack = true;
				donkeykongattackcooldown = 0;
			}
		}

		if (donkeykongattackcooldown >= 0.75F) {
			donkeykongattack = false;
		} else {
			donkeykongattackcooldown += Time.deltaTime;
		}
		
	}
	
}
	