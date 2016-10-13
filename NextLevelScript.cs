using UnityEngine;
using System.Collections;

public class NextLevelScript : MonoBehaviour {

    // respond on collisions
    void OnCollisionEnter(Collision collision)
    {
        // only do stuff if hit by a projectile
        if (collision.gameObject.tag == "Projectile")
        {
            // call the NextLevel function in the game manager
            GameManager.gm.NextLevel();
        }
    }
}
