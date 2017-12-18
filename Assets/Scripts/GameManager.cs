using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;

	public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
	}

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			//Debug.Log("GAME OVER");
			//Invoke("Restart", restartDelay);
			StartCoroutine(CollisionDelay());
		}
	}

	IEnumerator CollisionDelay(){
		Debug.Log ("GAME OVER");
		yield return new WaitForSeconds (1);
		Restart ();
	}
		

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
