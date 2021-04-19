/*
*** This script will be able to call one function to start the basic round ***
* Spawns a goal point
* When goal point collides with car, send call to here for spawn next
* Spawn ghost far away, spawn another goal point
* Count goals reached (public int)
* Occasional special goal that clears some or all of the

*** Also contained ***
* When ghost touches car, send call here for game over
* If car somehow falls out of range, game over
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameController : MonoBehaviour
{
	[Header("Prefabs")]
	// Goal point prefab
	public GameObject goal_pointPF;
	// Ghost prefab
	public GameObject ghostPF;
	// Goals reached
	[Header("GameObjects")]
	// Car game object
	public GameObject player_car;
	public GameObject first_ghost, ghosted_text, player_controls;

	[Header("Others")]
	public UnityEngine.UI.Text points_text;
	public Transform[] goal_spawn_point = new Transform[35];
	public Transform[] ghost_spawn_point = new Transform[9];
	public int goals_reached;
	SimpleCarController _scc;
	audioController _ac;
	bool first = true, paused = false;
	

	void Start()
	{
		GameObject _sccGO = GameObject.FindGameObjectWithTag("Player");
		GameObject _acGO = GameObject.FindGameObjectWithTag("Audio");
		_scc = _sccGO.GetComponent<SimpleCarController>();
		_ac = _acGO.GetComponent<audioController>();
	}

	public void beginBasicGame()
	{
		// Instantiate goal point
	}

	public void carTouched()
	{
		Debug.Log("Car touched");
		_scc.gameOver();
		_ac.playGameover();
		ghosted_text.SetActive(true);
		player_controls.SetActive(false);
	}

	public void goalDestroyed()
	{
		goals_reached++;
		points_text.text = goals_reached.ToString();
		_ac.playPoint();
		// Spawn goal point
		Instantiate(goal_pointPF, goal_spawn_point[Random.Range(0,34)]);

		// On first point, just set the first ghost active
		if (first)
		{
			first = false;
			first_ghost.SetActive(true);
			_ac.startGameplayMusic();
			return;
		}


		// Spawn other ghost at least 100 away from car
		float dist;
		int selected = Random.Range(0, 8);
		do
		{
			if (selected == 8) selected = 0;
			else selected++;
			dist = Vector3.Distance(ghost_spawn_point[selected].position, player_car.transform.position);
		} while (dist < 100);
		Instantiate(ghostPF, ghost_spawn_point[selected]);
	}

	public void togglePause()
	{
		if (paused)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;
		paused = !paused;
	}
}
