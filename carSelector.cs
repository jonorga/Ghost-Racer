using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelector : MonoBehaviour
{
	public WheelCollider[] wheel = new WheelCollider[4];
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
	void setCar1()
	{
		_scc.maxSteeringAngle = 25;
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

	void setCar2()
	{
		_scc.maxSteeringAngle = 45;
		for (int i = 0; i <= 3; i++)
		{
			wfc = wheel[i].forwardFriction;
			wfc.stiffness = 2;
			wheel[i].forwardFriction = wfc;
			wfc = wheel[i].sidewaysFriction;
			wfc.stiffness = 0.8f;
			wfc.extremumSlip = 25;
			wheel[i].sidewaysFriction = wfc;
		}
	}

	void setCar3()
	{
		carRB.mass = 4500;
		_scc.maxSteeringAngle = 50;
		for (int i = 0; i <= 3; i++)
		{
			wfc = wheel[i].sidewaysFriction;
			wfc.stiffness = 1;
			wheel[i].sidewaysFriction = wfc;
		}
	}
}
