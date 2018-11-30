using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : Movement {

    float[] raycasts;
    // Use t1his for initialization
    protected override void Start () {//TO DO: RECIBIR DEGENETIC MANAGER, 11 valores


        maxSpeed = 0.28f;
        maxAcceleration = 0.15f;
        maxBrake = 0.1f;
        friction = 0.05f;
        maxSteer = 0.04f;
        weight = 0.9f;
        raycasts = castRays(5);
    }

    protected override float AccelerationAxis()
    {
        // -1 descelerar, 1 acelerar
       /* if (raycasts[1] > raycasts[2] || raycasts[3] > raycasts[2])
        {
            return -1;
        }*/
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
    private float[] castRays(int nRay) //Recieves the number of rays to cast and returns the distance from the car to each object hits
    {
        float[] vector = new float[nRay];
        for (int angle = 0, i = 0; angle <= 180; angle += 180/(nRay - 1), i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle))), out hit, Mathf.Infinity);
            vector[i] = hit.distance;
            Debug.Log(i + " es " + hit.distance);
        }
        return vector;
    }

    // Update is called once per frame
    private void Update()
    {
        raycasts = castRays(5);
    }
}
