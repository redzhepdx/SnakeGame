using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {     
        if (GameManager.gm)
        {
            if (other.gameObject.tag =="Enemy" )
            {
                Destroy(other.gameObject);
                GameManager.gm.targetHit(5, 0);
            }
            else if (other.gameObject.tag == "EnemyNegative")
            {
                Destroy(other.gameObject);
                GameManager.gm.targetHit(-5, 0);
            }
        }
    }

}
