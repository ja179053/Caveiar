using UnityEngine;
using System.Collections;

public class GameOver : GameManager
{
	void Start ()
	{
		StartCoroutine (EndGame ());
	}
}
