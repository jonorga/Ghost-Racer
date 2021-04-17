using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAid : MonoBehaviour
{
	carAudio _carAudio;

	void Start()
	{
		GameObject pcGO = GameObject.FindGameObjectWithTag("Player");
		_carAudio = pcGO.GetComponent<carAudio>();
	}

    void OnTriggerEnter(Collider collider)
    {
    	if (!collider.name.Contains("Sphere") && !collider.name.Contains("Ghost"))
    		_carAudio.car_impact();
    }
}
