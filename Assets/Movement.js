#pragma strict

function Update () {
	if (Input.GetButtonDown("Jump"))
	{
		transform.position.y += 0.5;
	}
}