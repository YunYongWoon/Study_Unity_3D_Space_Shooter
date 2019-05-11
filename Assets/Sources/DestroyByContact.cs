using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    void Start() {

    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy")
            return;

        if (explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
