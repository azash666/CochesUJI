using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "CC_ME_R4")
        {
            //decidimos qué hacer si colisionan
        }
		
	}
	

}
