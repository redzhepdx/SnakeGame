using UnityEngine;
using System.Collections;

public class IntelligentBomb : MonoBehaviour {

	enum State { IDLE, SEARCH};
	State currentState;

	public Transform bombExplodeExplosion;
	
	public float sightRange = 20f;
	public float searchingTurnSpeed = 120f;
	public float searchDuration = 4f;
	
	float explosionTime = 20;

	void Start () {
		currentState = State.IDLE;
	}
	
	void Update () {

		if (currentState == State.SEARCH)
		{
			Search();
		}
	}

	void Search()
	{
		for (int i = 0; i < 1000;i++ )
		{
			transform.Rotate(0, searchingTurnSpeed * Time.deltaTime, 0);

			Ray ray = new Ray(transform.position + Vector3.forward * 2, transform.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, sightRange) && hit.collider.CompareTag("Player"))
			{
				GetComponent<Renderer>().material.color = Color.red;
				Invoke("Explode",2);
				break;
			}

		}

		currentState = State.IDLE;
   
	}

	void Explode(){

		Destroy(gameObject);
		Instantiate(bombExplodeExplosion, transform.position, transform.rotation);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			currentState = State.SEARCH;
		}

	}

}
