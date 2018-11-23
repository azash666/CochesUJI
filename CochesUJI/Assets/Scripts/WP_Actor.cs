using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour {
    float speed = 5.0f;
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
            target = other.gameObject.GetComponent<Waypoint>.NextPoint;
    }
}
