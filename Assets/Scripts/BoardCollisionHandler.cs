using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollisionHandler : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Dart") {

			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			//other.gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;

            //other.gameObject.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, -90f, 0f);
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f); // Set rotation to (0, 90, 0)


        }
    }
}
