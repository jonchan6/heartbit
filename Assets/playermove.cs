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
	private Vector3 velocity;
	public bool jumpable = true;
	
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
			if (state == State.Jump)
			{
				// spawn landing particles
			}
			break;
			
		case State.Jump:
			velocity = jumpForce * Vector3.up;
			
			// play animation
			break;
		
		case State.Wall:
			Debug.Log ("Wall State Set");
			break;
			
		case State.Air:
			break;
		}
	
		state = newState;
	}
	
	void Awake()
	{
		characterController = GetComponent<CharacterController>();
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Hello");
	}
	
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("Hello");
	}
	
	/*
	bool CheckWall(Vector3 motion)
	{
		return Physics.CheckSphere(transform.position + motion, characterController.radius, ~(1<<8));
	}

	*/
	
	void Update()
	{
		//if (state == State.Idle)
		
		//state = State.Idle;
		
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
	}
	
}
	