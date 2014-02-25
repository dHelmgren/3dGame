using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax, yMin, yMax;
}


public class PlayerController : MonoBehaviour
{
	public float MoveSpeed = 5.0f;
	public float RunSpeed = 30.0f;
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;// The damping for the speed parameter
	public static bool onGround = true;
	public Boundary boundary;
	public static float cameraYPos = 0.5583928f;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float speed = 0;
		if ((moveVertical != 0.0f) || (moveHorizontal != 0.0f)) 
		{

			if(Input.GetKey("r"))
			{
				//animation.Play("run");
				//speed = RunSpeed;
				speed = MoveSpeed;

			}
			else{
				speed = MoveSpeed;
			}

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rigidbody.velocity = movement * speed;
			Rotating(moveHorizontal,moveVertical);
			rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax), 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
			);
		}
		else 
		{
			rigidbody.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
			rigidbody.position = new Vector3 
				(
					Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
					Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax), 
					Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
					);
		}

		rigidbody.position = new Vector3 (rigidbody.position.x, cameraYPos, rigidbody.position.z);
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax), 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);

	}	

	void Rotating (float horizontal, float vertical)
	{
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation(newRotation);
	}


}
