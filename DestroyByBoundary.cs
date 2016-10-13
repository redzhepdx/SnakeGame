using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {


	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Boundary")
			Destroy (gameObject);
	}
}
