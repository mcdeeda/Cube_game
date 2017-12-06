using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;     // A reference to PlayerMovement script
	// This function runs when you hit another object.
	void OnCollisionEnter (Collision collisionInfo)
	{
		
		if(collisionInfo.gameObject.name == "Ground")
		{
			movement.isGrounded = true;
		}
		if (collisionInfo.gameObject.name == "Wall") //When colliding with wall
		{
			Physics.gravity = new Vector3 (0, -10, 0);
			movement.isOnWall = true;
		}
		// Check if the object you collided with has a tag called "Obstacle".
		if (collisionInfo.collider.tag == "Obstacle")
		{
			movement.enabled = false;   // Disable the players movement.
			FindObjectOfType<GameManager>().EndGame();
		}
	}
	void OnCollisionExit (Collision collisionInfo)
	{
		Physics.gravity = new Vector3 (0, -30, 0);
		movement.isOnWall = false;
	}

}
