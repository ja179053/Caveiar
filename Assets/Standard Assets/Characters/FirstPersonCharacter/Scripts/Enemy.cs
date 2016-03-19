using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class Enemy : MonoBehaviour
	{

		public float maxHealth = 10.0f, currentHealth, chaseRange = 5.0f, attackRange = 1.5f, attackCD = 3.0f, distance, speed = 1;
		float attackCDLeft;
		FirstPersonController player;
		Animation anim;
		public AnimationClip idle, chasing, attacking, die;
		public enum State{
			Idle,
			Attacking,
			Chasing,
			Dead
		}
		public State currentState;

		// Use this for initialization
		void Start ()
		{
			currentHealth = maxHealth;
			player = FindObjectOfType<FirstPersonController> ();
			anim = GetComponent<Animation> ();
			anim.Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			distance = Vector3.Distance (transform.position, player.transform.position);
			switch (currentState) {
			case State.Idle:
				anim.clip = idle;
				anim.Play ();
				if(distance <= chaseRange){
					currentState = State.Chasing;
				} 
				break;
			case State.Chasing:
				//Chasing
				transform.LookAt (player.transform.position);
				//	anim.SetFloat ("speed", 1.0f);

				if (attackCDLeft > 0.0f) {
					attackCDLeft -= Time.deltaTime;
				}
				anim.clip = chasing;
				anim.Play ();
				transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
				if(distance <= attackRange){
					currentState = State.Attacking;
				} else if (distance > chaseRange){
					currentState = State.Idle;
				}
				break;
			case State.Dead:
				anim.clip = die;
				anim.wrapMode = WrapMode.Once;
				anim.Play ();
				break;
			case State.Attacking:

				Attack ();
				attackCDLeft = attackCD;
				anim.clip = attacking;
				anim.Play ();
				break;
			}
			if (currentHealth <= 0.0f) {
				currentState = State.Dead;
			}
		}

		public void LoseHealth (float damage)
		{
			currentHealth -= damage;
		}
		public void Die(){
			//Destroy (this.gameObject);
		}

		public void Attack ()
		{
			if (attackCDLeft <= 0.0f) {
				player.LoseHealth (2f);
				Debug.Log ("The player lost 2 health");
			}
		}
	}
}
