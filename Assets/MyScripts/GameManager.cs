using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public float finishWaitSeconds = 5;
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
			Debug.Break();
		}
	}
	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player") {
			Debug.Log("You win");
			StartCoroutine (EndGame());
		}
	}
	protected IEnumerator EndGame(){
		yield return new WaitForSeconds(finishWaitSeconds);
		Application.LoadLevel (0);
	}
}
