using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public Transform[] renderedFrontWheels = new Transform[2];
    public Transform mainCam;
    Rigidbody carRB;
    float motorSpeed = 0, steeringAngle = 0, maxSpeed = 50;
    float camPosition = 0, maxLeanDistance = 2, leanIncrement = 0.05f, safeGuard = 0.07f, leanIncrementFixed = 0.05f;
    public bool forward = false, back = false, left = false, right = false;
    bool ghosted = false;
        
    public void FixedUpdate()
    {
    	if (ghosted)
    		return;
        float motor = maxMotorTorque * motorSpeed;// * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * steeringAngle;//Input.GetAxis("Horizontal");
        leanIncrement = (Mathf.Abs(motorSpeed)/50) * 0.05f;
        
        
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }


        if (forward) //forward
        {
        	if (motorSpeed < 0)
        		motorSpeed = 0;
        	else if (motorSpeed < maxSpeed)
        		motorSpeed += 0.5f;
        	if (transform.position.y < 5)
	        	carRB.AddForce(transform.forward * 250000);
        }
        else if (back)//back
        {
        	if (motorSpeed > 0)
	        	motorSpeed = 0;
	        else if (motorSpeed > -maxSpeed)
	        	motorSpeed -= 0.5f;
        }
        else if (Input.GetKey("q"))
        {
        	carRB.velocity = Vector3.zero;
        }
        else
        {
        	if (motorSpeed > 0)
	        	motorSpeed -= 0.2f;
	        else if (motorSpeed < 0)
	        	motorSpeed += 0.4f;
	        if (motorSpeed < 0.15f && motorSpeed > -0.15f)
	        	motorSpeed = 0;
        }
        //Debug.Log("motor speed: " + motorSpeed);

        
        if (right)//right
        {
        	steeringAngle = 1;
        	renderedFrontWheels[0].localRotation = Quaternion.Euler(0, 25, 0);
        	renderedFrontWheels[1].localRotation = Quaternion.Euler(0, 25, 0);
        	if (camPosition < maxLeanDistance)
        		camPosition += leanIncrement;
        	mainCam.localPosition = new Vector3(camPosition, 8.9f, -21.24f);
        	mainCam.localRotation = Quaternion.Euler(7.1f, -camPosition, 0);
        }
        else if (left)//left
        {
        	steeringAngle = -1;
        	renderedFrontWheels[0].localRotation = Quaternion.Euler(0, -25, 0);
        	renderedFrontWheels[1].localRotation = Quaternion.Euler(0, -25, 0);
        	if (camPosition > -maxLeanDistance)
        		camPosition -= leanIncrement;
        	mainCam.localPosition = new Vector3(camPosition, 8.9f, -21.24f);
        	mainCam.localRotation = Quaternion.Euler(7.1f, -camPosition, 0);
        }
        else
        {
        	steeringAngle = 0;
        	renderedFrontWheels[0].localRotation = Quaternion.Euler(0, 0, 0);
        	renderedFrontWheels[1].localRotation = Quaternion.Euler(0, 0, 0);
        	if (camPosition < -safeGuard)
        		camPosition += leanIncrementFixed;
        	if (camPosition > safeGuard)
        		camPosition -= leanIncrementFixed;
        	
        	mainCam.localPosition = new Vector3(camPosition, 8.9f, -21.24f);
        	mainCam.localRotation = Quaternion.Euler(7.1f, -camPosition, 0);
        }
    }

    public void Start()
    {
    	carRB = transform.GetComponent<Rigidbody>();
    }

    public void gameOver()
    {
    	ghosted = true;
    }

    public void forwardClick(bool clicked)
    {
        if (clicked)
            forward = true;
        else
            forward = false;
    }

    public void backwardClick(bool clicked)
    {
        if (clicked)
            back = true;
        else
            back = false;
    }

    public void leftClick(bool clicked)
    {
        if (clicked)
            left = true;
        else
            left = false;
    }

    public void rightClick(bool clicked)
    {
        if (clicked)
            right = true;
        else
            right = false;
    }

}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
