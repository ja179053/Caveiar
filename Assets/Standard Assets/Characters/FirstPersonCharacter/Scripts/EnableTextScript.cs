using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class EnableTextScript : MonoBehaviour
	{
		FirstPersonController fpsc;
		public GameObject colliderText;
		public string whatToSay = "You've bumped into something";
		public float waitTime = 2;
	
		void OnTriggerStay (Collider c)
		{
			fpsc = FindObjectOfType<FirstPersonController> ();
			colliderText.SetActive(true);
			if (!fpsc.slowMo) {
				fpsc.slowMo = true;
				StartCoroutine (WaitToReact ());
			}
		}

		IEnumerator WaitToReact ()
		{
			Debug.Log ("running");
			colliderText.GetComponent<Text>().text = whatToSay;
			yield return new WaitForSeconds(waitTime);
			fpsc.slowMo = false;
			colliderText.SetActive(false);
			Destroy (this.gameObject);
		}
	}
}
