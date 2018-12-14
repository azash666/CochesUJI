using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : Movement {

    float[] raycasts;
    // Use this for initialization
    protected override void Start () {//TO DO: RECIBIR DEGENETIC MANAGER, 11 valores

        direction=Mathf.Deg2Rad * transform.eulerAngles.y;
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
        if (raycasts[3]<20)
        {
            return -1;
        }
        return 1;
    }


    protected override float SteerAxis()
    { 
        if (raycasts[1] > raycasts[2] || raycasts[3] > raycasts[2])
            if (raycasts[1] > raycasts[3])
                return -1;
            else return 1;
          
        if (raycasts[0] > raycasts[4]) 
            return -0.3f;
        else if (raycasts[4] > raycasts[0])
            return 0.3f;
        return 0;
    }
    private float[] castRays(int nRay) //Recieves the number of rays to cast and returns the distance from the car to each object hits
    {
        float[] vector = new float[nRay];
        int i=0;
        float dir = direction;
        for (float  angle = dir-Mathf.PI/2; i<nRay; angle += Mathf.PI/(nRay - 1), i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, (new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle))), out hit, Mathf.Infinity);
            vector[i] = hit.distance;
            if (vector[i] == 0 || vector[i]== Mathf.Infinity) vector[i] = 100000;
            //Debug.Log(i + " es " + vector[i] + "(ÁNGULO = " + Mathf.Rad2Deg*angle + "grados)" + dir*Mathf.Rad2Deg); 
        }
        return vector;
    }

    // Update is called once per frame
    private void Update()
    {
        raycasts = castRays(5);
    }
}
