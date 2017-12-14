using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;
	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 300f;  // Variable that determines the sideways force
	public float jumpheight = 1000f; //jump height variable
	public bool isGrounded = true;
	public bool isOnWall = false;
    public string wallSide = "";
	public float walljumpwidth = 10f;
	public float walljumpheight = 10f;
	public float walljumpforce = 40f;

	// Marked this as "Fixed"Update because
	// using it to mess with physics.
	void FixedUpdate ()
	{
		print (isOnWall);
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d") || Input.GetKey("right"))	// If the player is pressing the "d" or right arrow key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if(isOnWall == true && isGrounded == false && wallSide == "Left")
            {
                print("rightjumping");
                rb.AddForce(walljumpwidth * Time.deltaTime, walljumpheight * Time.deltaTime, walljumpforce * Time.deltaTime, ForceMode.VelocityChange);
            }
		}

			if (Input.GetKey("a") || Input.GetKey("left"))  // If the player is pressing the "a" or left arrow key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if(isOnWall == true && isGrounded == false && wallSide == "Right")
            {
                print("rightjumping");
                rb.AddForce(-walljumpwidth * Time.deltaTime, walljumpheight * Time.deltaTime, walljumpforce * Time.deltaTime, ForceMode.VelocityChange);
            }
		}

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
		if (Input.GetKeyDown ("w") || Input.GetKeyDown ("up") && isGrounded == true) 
		{
			isGrounded = false;
			rb.AddForce (0, jumpheight * Time.deltaTime, 0, ForceMode.VelocityChange);
		}
        
	}
}
	
