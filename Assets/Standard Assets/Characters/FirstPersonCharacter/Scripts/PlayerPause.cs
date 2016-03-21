using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson{
public class PlayerPause : MonoBehaviour {
		FirstPersonController fpsc;
		AudioSource asource;
		bool running;
		public float pauseTime = 3;
	// Use this for initialization
	void Start () {
			asource = GetComponent<AudioSource> ();
			fpsc = FindObjectOfType<FirstPersonController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay(Collider c){
		if (c.gameObject.tag == "Player") {
				running = true;
				StartCoroutine(Pause());
		}
	}
		IEnumerator Pause(){
			fpsc.canMove = false;
			if (asource != null) {
				asource.Play ();
			}
			yield return new WaitForSeconds(pauseTime);
			fpsc.canMove = true;
			Destroy (this.gameObject);

		}

	}
}
