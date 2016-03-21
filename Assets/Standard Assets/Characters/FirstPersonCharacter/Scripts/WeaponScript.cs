using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class WeaponScript : MonoBehaviour
	{
		public float damage = 1;
		public GameObject weapon;
		public Collider collider;
		FirstPersonController player;
		void Start(){
			player = FindObjectOfType<FirstPersonController> ();
		}
		void OnTriggerStay (Collider c)
		{
			if (c.gameObject.tag == "Player") {
				Debug.Log ("close enough");
				weapon.SetActive (true);
				player.damage = damage;
				if (collider != null){
					collider.enabled = !collider.enabled;
				}
				Destroy (gameObject);
			}
		}
	}
}
