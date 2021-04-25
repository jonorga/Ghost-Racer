using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelector : MonoBehaviour
{
	public WheelCollider[] wheel = new WheelCollider[4];
	public GameObject[] car_body = new GameObject[3];
	SimpleCarController _scc;
	Rigidbody carRB;
	WheelFrictionCurve wfc;

	void Start()
	{
		GameObject _sccGO = GameObject.FindGameObjectWithTag("Player");
		_scc = _sccGO.GetComponent<SimpleCarController>();
		carRB = _sccGO.GetComponent<Rigidbody>();
		
	}

	/*
	All altered car values:
	- Steering angle
	- Forward friction
		- stiffness
	- Sideways friction
		- stiffness
		- extremum slip
	*/

	// Default car
	public void setCar1()
	{
		carRB.mass = 8000;
		_scc.maxSteeringAngle = 25;
		car_body[0].SetActive(true);
		car_body[1].SetActive(false);
		car_body[2].SetActive(false);
		for (int i = 0; i <= 3; i++)
		{
			wfc = wheel[i].forwardFriction;
			wfc.stiffness = 7;
			wheel[i].forwardFriction = wfc;
			wfc = wheel[i].sidewaysFriction;
			wfc.stiffness = 2;
			wfc.extremumSlip = 10;
			wheel[i].sidewaysFriction = wfc;
		}
	}

	public void setCar2()
	{
		carRB.mass = 8000;
		_scc.maxSteeringAngle = 90;
		car_body[0].SetActive(false);
		car_body[1].SetActive(false);
		car_body[2].SetActive(true);
		for (int i = 0; i <= 3; i++)
		{
			wfc = wheel[i].forwardFriction;
			wfc.stiffness = 6;
			wheel[i].forwardFriction = wfc;
			wfc = wheel[i].sidewaysFriction;
			wfc.stiffness = 10f;
			wfc.extremumSlip = 25;
			wheel[i].sidewaysFriction = wfc;
		}
	}

	public void setCar3()
	{
		carRB.mass = 4500;
		_scc.maxSteeringAngle = 80;
		car_body[0].SetActive(false);
		car_body[1].SetActive(true);
		car_body[2].SetActive(false);
		for (int i = 0; i <= 3; i++)
		{
			wfc = wheel[i].sidewaysFriction;
			wfc.stiffness = 1f;
			wheel[i].sidewaysFriction = wfc;
		}
	}
}
