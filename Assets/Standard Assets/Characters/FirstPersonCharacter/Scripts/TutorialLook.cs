using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.FirstPerson{
public class TutorialLook : MonoBehaviour {
	float lookedTime;
	public float lookTime;
	public ParticleSystem rock;
	FirstPersonController fpsc;
	// Use this for initialization
	void Start () {
			rock.enableEmission = false;
			fpsc = FindObjectOfType<FirstPersonController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			RaycastHit rayhit;
			Debug.DrawRay (transform.position, transform.forward * 10);
			if (Physics.Raycast (transform.position, transform.forward, out rayhit, 10)) {
				if (rayhit.collider.name == "Tutorial Look") {
					lookedTime += Time.fixedDeltaTime;
					if (lookedTime > lookTime) {
						rayhit.collider.GetComponent<Renderer> ().material.color = Color.red;
						rayhit.collider.GetComponent<ParticleSystem> ().enableEmission = false;
						rock.enableEmission = true;
						fpsc.canMove = true;
					}
				}
			}
		}
	}
}
