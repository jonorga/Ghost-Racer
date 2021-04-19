using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAnims : MonoBehaviour
{
    float speed = 3.0f;
    Vector3 target = new Vector3(5, 5.85f, 40);
    bool done = false;

    void OnEnable()
    {
    	done = false;
    	StartCoroutine(mainEnum());
    }

	IEnumerator mainEnum()
	{
		for (;;)
		{
			if (done)
				break;
			target = new Vector3(Random.Range(-62, 63), 5.85f, Random.Range(-60, 85));
			speed = Random.Range(2, 10);
			yield return new WaitForSeconds(Random.Range(5, 15));
		}
	}

	void beginningGame()
	{
		//StopCoroutine(mainEnum());
		done = true;
		target = new Vector3(5, 5.85f, 250);
		speed = 55;
	}

	void FixedUpdate()
    {
        transform.LookAt(target);

        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

	//x: -42 : 42
	//z: -50 : 60
}
