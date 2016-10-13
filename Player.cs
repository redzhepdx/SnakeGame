using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public int Health = 100;
    public Text playerHealth;
    [HideInInspector]
    public bool isMainBossLevel = false;

    void Update()
    {
        if(Health <= 0)
        {
            GameManager.gm.EndGame();
            DestroyImmediate(GameObject.FindGameObjectWithTag("Boss"));
        }

        playerHealth.text ="Player Health : " + Health.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlackHoleBlast" || collision.gameObject.tag == "Stone" || collision.gameObject.tag == "Boss")
        {
            Destroy(collision.gameObject);

            Health -= 30;

        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            GameManager.gm.RestartGame();
        }

    }

    void OnTriggerEnter(Collider other)
    {
       
    }
   

}
