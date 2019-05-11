using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject shot;
    public Transform firePosition;
    float speed = 5;    // 속도
    float tilt = 5;     // 회전값

    void Start() {

    }

    // 단순한 키 입력
    void Update() { 
        if(Input.GetButtonDown("Fire1") == true) {
            Instantiate(shot, firePosition.position, firePosition.rotation);
        }
    }

    // 물리적인 움직임을 업데이트
    void FixedUpdate() { 
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(dirX, 0, dirY);

        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
