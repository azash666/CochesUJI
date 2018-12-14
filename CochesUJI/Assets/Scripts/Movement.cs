using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour {

    protected float direction; //Angle in radians, ranges from 0 to 2*PI
    private float speed = 0; //Ranges from 0 to maxSpeed
    private float acceleration = 0; //Ranges from -maxBrake to maxAcceleration
    protected float maxSpeed;
    protected float maxAcceleration;
    protected float maxBrake;
    protected float friction;
    protected float maxSteer;
    protected float weight;
    
    protected abstract void Start();
    protected abstract float AccelerationAxis(); // Must return a float betweeen -1 and 1 with the acceration axis input
    protected abstract float SteerAxis(); // Must return a float betweeen -1 and 1 with the steering axis input

    //TO DO: FRENAR EN COLISION PARED o al salirse circuito

	void FixedUpdate () {
        float axis = AccelerationAxis();
        if (axis>=0) acceleration = maxAcceleration * axis; //Assigns a value relative to maximun acceration and the input recieved (if accelerating)
        else acceleration = maxBrake * axis; //Assigns a value relative to maximun braking and the input recieved (if braking)



        speed = Mathf.Clamp(speed + (acceleration - friction)/weight * Time.deltaTime, 0, maxSpeed); //Assigns a value to speed according to acceleration, friction and weight clamped between 0 and the maximum speed

        //Assigns direction a radian value depending on the input and the maximum steering value
        if (speed > 0)
        {
            direction += maxSteer * SteerAxis();
            if (direction >= 2 * Mathf.PI) direction -= 2 * Mathf.PI;
        }

        transform.eulerAngles = new Vector3(0, Mathf.Rad2Deg * direction, 0); //Rotates the car to the direction it is going towards
        transform.position += new Vector3 (Mathf.Sin(direction)*speed, 0, Mathf.Cos(direction)*speed); //Moves the car to its new position
    }


}