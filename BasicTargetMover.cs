using UnityEngine;
using System.Collections;

public class BasicTargetMover : MonoBehaviour {

    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.1f;

    public bool doSpin = true;
    public bool doMotion = false;
	
	void Update () {

        if (doSpin)
        {
            //Rotate around the up axis of the gameObject
            gameObject.transform.Rotate(Vector3.up*spinSpeed*Time.deltaTime);
        }

        if (doMotion)
        {
            //Move up and down over time
            gameObject.transform.Translate(Vector3.up*Mathf.Cos(Time.timeSinceLevelLoad)*motionMagnitude);
        }

	}
}
