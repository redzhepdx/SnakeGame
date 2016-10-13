using UnityEngine;
using System.Collections;

public class FPSCameraController : MonoBehaviour {

	private Vector3 ShakePosition;
	private float RandomShakeX , RandomShakeY;
	private float PreviosShakeX = 1f,PreviosShakeY = 1f;

	[HideInInspector]
	public float ShakeXRange;//		walking:0.1f	running:0.1f	sprint:0.2f
	[HideInInspector]
	public float ShakeYRange;//		walking:0.1f	running:0.2f	sprint:0.4f
	[HideInInspector]
	public float ShakeXSmoothing;//	walking:15f		running:20f		sprint:40f
	[HideInInspector]
	public float ShakeYSmoothing;//	walking:25f		running:25f		sprint:55f

	void Awake () 
	{
		ShakePosition = transform.localPosition;
	}


	void FixedUpdate () {

		if (Input.GetButton("Vertical")) 
		{
			ShakeXRange = 0.1f;
			ShakeYRange = 0.2f;
			ShakeXSmoothing = 20f;
			ShakeYSmoothing = 25f;

			if(Input.GetKey(KeyCode.LeftControl))
			{
				ShakeXRange = 0.1f;
				ShakeYRange = 0.1f;
				ShakeXSmoothing = 15f;
				ShakeYSmoothing = 25f;
			}
			if(Input.GetKey(KeyCode.LeftShift))
			{
				ShakeXRange = 0.2f;
				ShakeYRange = 0.4f;
				ShakeXSmoothing = 40f;
				ShakeYSmoothing = 55f;
			}


			if (transform.localPosition == ShakePosition) {

				RandomShakeY = Random.Range (-ShakeYRange, ShakeYRange);

				if (PreviosShakeY * RandomShakeY > 0)
					RandomShakeY = -RandomShakeY;

				PreviosShakeY = RandomShakeY;
				RandomShakeX = Random.Range (-ShakeXRange, ShakeXRange);

				if (PreviosShakeX * RandomShakeX > 0 && RandomShakeY < 0) 
				{
					RandomShakeX = -RandomShakeX;
					PreviosShakeX = RandomShakeX;
				}

				ShakePosition = new Vector3 (RandomShakeX, 1 + RandomShakeY, transform.localPosition.z);

			} else if (transform.localPosition != ShakePosition) {
				transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3 (RandomShakeX, transform.localPosition.y, transform.localPosition.z), ShakeXSmoothing * Time.deltaTime);
				transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3 (transform.localPosition.x, 1 + RandomShakeY, transform.localPosition.z), ShakeYSmoothing * Time.deltaTime);
			}
		} else if(Input.GetButtonUp("Vertical")) {
			transform.localPosition = new Vector3(0f,1f,0f);
			ShakePosition = transform.localPosition;
		}

		if (Input.GetButton ("Horizontal") && !Input.GetButton ("Vertical")) 
		{
			ShakeXRange = 0.1f;
			ShakeYRange = 0.2f;
			ShakeXSmoothing = 20f;
			ShakeYSmoothing = 25f;
			
			if(Input.GetKey(KeyCode.LeftControl))
			{
				ShakeXRange = 0.1f;
				ShakeYRange = 0.1f;
				ShakeXSmoothing = 15f;
				ShakeYSmoothing = 25f;
			}
			if(Input.GetKey(KeyCode.LeftShift))
			{
				ShakeXRange = 0.2f;
				ShakeYRange = 0.4f;
				ShakeXSmoothing = 40f;
				ShakeYSmoothing = 55f;
			}

			if (transform.localPosition == ShakePosition) {
				
				RandomShakeY = Random.Range (-ShakeYRange, ShakeYRange);
				
				if (PreviosShakeY * RandomShakeY > 0)
					RandomShakeY = -RandomShakeY;
				
				PreviosShakeY = RandomShakeY;
				RandomShakeX = Random.Range (-ShakeXRange, ShakeXRange);
				
				if (PreviosShakeX * RandomShakeX > 0 && RandomShakeY < 0) 
				{
					RandomShakeX = -RandomShakeX;
					PreviosShakeX = RandomShakeX;
				}
				
				ShakePosition = new Vector3 (RandomShakeX, 1 + RandomShakeY, transform.localPosition.z);
				
			} else if (transform.localPosition != ShakePosition) {
				transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3 (RandomShakeX, transform.localPosition.y, transform.localPosition.z), ShakeXSmoothing * Time.deltaTime);
				transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3 (transform.localPosition.x, 1 + RandomShakeY, transform.localPosition.z), ShakeYSmoothing * Time.deltaTime);
			}
		} else if(Input.GetButtonUp("Horizontal")){
			transform.localPosition = new Vector3(0f,1f,0f);
			ShakePosition = transform.localPosition;
		}
	}
}
