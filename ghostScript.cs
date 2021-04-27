using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
	// lean towards car
	// move towards car

	public float speed = 3.0f;
	Transform playerCar;
	gameController _gm;


	void Start()
	{
		GameObject playerCarGO = GameObject.FindGameObjectWithTag("Player");
		GameObject _gmGO = GameObject.FindGameObjectWithTag("GameController");
		playerCar = playerCarGO.GetComponent<Transform>();
		_gm = _gmGO.GetComponent<gameController>();
		StartCoroutine(speedUp());
	}

	void game_end()
	{
		Destroy(gameObject);
	}

	IEnumerator speedUp()
	{
		for (;;)
		{
			yield return new WaitForSeconds(20);
			speed += 2;
		}
	}

	public void touchedCar()
	{
		_gm.carTouched();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(playerCar);

        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerCar.position.x, 5.85f, playerCar.position.z), step);
    }
}
