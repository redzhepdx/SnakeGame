using UnityEngine;
using System.Collections;

public class TimedObjectDestructor : MonoBehaviour {

	public float timeOut = 1.0f;
	public bool detachChildren = false;

	void Awake () {
		Invoke ("DestroyNow", timeOut);
	}
	

	void DestroyNow ()
	{
		// detach the children before destroying if specified
		if (detachChildren) {
			transform.DetachChildren ();
		}
		Destroy(gameObject);
	}
}
