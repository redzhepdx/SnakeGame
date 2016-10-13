using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
    
    void Awake()
    {
        GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
    }
}
