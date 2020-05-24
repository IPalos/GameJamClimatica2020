using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {

	public GravityAttractor attractor;
	private Transform myTransform;

	void Start () {
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = transform;
	}

	void FixedUpdate () {
		if (attractor) {
			attractor.Attract (myTransform);
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "planet") {
			GravityAttractor obj = col.GetComponent ("GravityAttractor") as GravityAttractor;
			if (obj) {
				attractor = obj;
			}
		}

	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "planet") {
			attractor = null;

		}
	}

}