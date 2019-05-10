using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed = 5;
    void Start() {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1) * speed;
    }
}
