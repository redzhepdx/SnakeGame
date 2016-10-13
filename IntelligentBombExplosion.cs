using UnityEngine;
using System.Collections;

public class IntelligentBombExplosion : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Stuff"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (collision.gameObject.CompareTag("SnakeBit"))
        {
            Destroy(collision.gameObject);
        }

    }



}
