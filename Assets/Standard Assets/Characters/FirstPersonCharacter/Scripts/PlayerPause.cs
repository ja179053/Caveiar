using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class PlayerPause : MonoBehaviour
	{
		FirstPersonController fpsc;
		AudioSource asource;
		bool used;
		public float pauseTime = 3;

		void Start ()
		{
			asource = GetComponent<AudioSource> ();
			fpsc = FindObjectOfType<FirstPersonController> ();
		}

		void OnTriggerEnter (Collider c)
		{
			if (c.gameObject.tag == "Player") {
				StartCoroutine (Pause ());
			}
		}

		IEnumerator Pause ()
		{
			if (!used) {
				used = true;
				fpsc.slowMo = true;
				if (asource != null && !asource.isPlaying) {
					asource.PlayOneShot (asource.clip);
				}
				yield return new WaitForSeconds (pauseTime);
				fpsc.slowMo = false;
				Destroy (this.gameObject);
			}
		}

	}
}
