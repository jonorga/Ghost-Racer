using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAid : MonoBehaviour
{
	public ghostScript gs;

	void OnTriggerEnter(Collider collider)
	{
		gs.touchedCar();
	}
}
