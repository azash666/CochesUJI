using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : Movement {
    float speedWay = 5.0f;
    public Transform target;
    // Use this for initialization
    override void Start () {//TO DO: RECIBIR DEGENETIC MANAGER, 11 valores

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
    }


    protected override float SteerAxis()
    {
        // -1 izquierda, 1 derecha
    }


    // Update is called once per frame
    void Update () {
        transform.Translate(new Vector3(0, 0, speedWay * Time.deltaTime));
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            target = other.gameObject.GetComponent<Waypoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
}
