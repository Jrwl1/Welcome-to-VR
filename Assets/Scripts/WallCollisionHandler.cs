using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionHandler : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Dart") {

			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			other.gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
		}
	}
}
