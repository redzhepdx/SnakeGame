using UnityEngine;
using System.Collections;

public class DestroyProjectileByCollision : MonoBehaviour {

	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "Player")
			Destroy (gameObject);
		
	}
}
