using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAudio : MonoBehaviour
{
    public AudioSource idle, rev;
    public AudioSource[] crash = new AudioSource[3];
    SimpleCarController _scc;
    Rigidbody rb;
    float mag;

    void FixedUpdate()
    {
    	mag = rb.velocity.magnitude;

    	if(!_scc.forward)
    	{
    		idle.pitch = 0.96f + ((mag/100)*0.14f);
    		if (!idle.isPlaying)
    			idle.Play();
    		if (rev.isPlaying)
    			rev.Stop();
    	}
    	else
    	{
    		if (idle.isPlaying)
	    		idle.Stop();
	    	if (!rev.isPlaying)
	    		rev.Play();
    	}
    }



    void Start()
    {
    	_scc = gameObject.GetComponent<SimpleCarController>();
    	rb = gameObject.GetComponent<Rigidbody>();
    }

    public void car_impact()
    {
    	int sel = Random.Range(0,3);
    	crash[sel].volume = mag/100;
    	crash[sel].Play();
    }
}
