using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public abstract class Quests : MonoBehaviour
	{
		public Collider newCollider;
		protected void SwitchCollider(){
			if (newCollider != null){
				newCollider.enabled = !newCollider.enabled;
			}
		}
	}
}
