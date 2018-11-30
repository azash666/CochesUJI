using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : Movement {

    protected override void Start()
    {
        //TO DO: DISCUTIR ESTOS VALORES
        maxSpeed=0.45f;
        maxAcceleration=0.25f;
        maxBrake=0.1f;
        friction=0.08f;
        maxSteer=0.04f;
        weight=0.9f;
}
    protected override float AccelerationAxis() {
        return Input.GetAxis("Vertical");
    }
    protected override float SteerAxis() {
        return Input.GetAxis("Horizontal");
    }

}
