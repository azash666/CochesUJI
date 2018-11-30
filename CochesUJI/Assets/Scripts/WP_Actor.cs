using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : Movement {
    float speedWay = 5.0f;
    public Transform target;

    Vector3 StartPosition;
    Quaternion startRotation;
    Rigidbody rb;
    float[] raycasts = new float[5];
    // Use t1his for initialization
    protected override void Start () {//TO DO: RECIBIR DEGENETIC MANAGER, 11 valores

        maxSpeed = 0.28f;
        maxAcceleration = 0.15f;
        maxBrake = 0.1f;
        friction = 0.05f;
        maxSteer = 0.04f;
        weight = 0.9f;
    }

    protected override float AccelerationAxis()
    {
        // -1 descelerar, 1 acelerar
        if (raycasts[1] > raycasts[2] || raycasts[3] > raycasts[2])
        {
            return -1;
        }
        return 1;
    }


    protected override float SteerAxis()
    {
        // -1 izquierda, 1 derecha
        if(raycasts[1] > raycasts[2])
        {
            if (raycasts[1] > raycasts[3])
                return -1;
            else return 1;
        }
        else if(raycasts[3] > raycasts[2])
        {
            return 1;
        }
        return 0;
    }


    // Update is called once per frame

}
