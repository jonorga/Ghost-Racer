using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camObject : MonoBehaviour
{
public Transform car;
public Transform cam;
Rigidbody carRB; 

	void FixedUpdate()
	{
		transform.position = car.position;
		transform.rotation = Quaternion.Euler(0, car.eulerAngles.y, 0);
	}
}
