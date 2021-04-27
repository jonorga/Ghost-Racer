using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
	gameController _gc;

	void Start()
	{
		GameObject gcGO = GameObject.FindGameObjectWithTag("GameController");
		_gc = gcGO.GetComponent<gameController>();
	}

	void OnTriggerEnter(Collider collider)
	{
		_gc.goalDestroyed();
		Destroy(gameObject.transform.parent.gameObject);
	}

	void game_end()
	{
		Destroy(gameObject.transform.parent.gameObject);
	}
}
