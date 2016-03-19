using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class colliderbear : MonoBehaviour {
	public Text colliderText;
	// Use this for initialization
	void Start () {
		colliderText.enabled = false;
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider c) {
		colliderText.enabled = true;
		colliderText.text = "You've bumped into something";
		Debug.Log ("You've bumped into something");
	}
}
