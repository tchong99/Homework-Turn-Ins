using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    // Initialize Variables
    public float speed = 5;
    public Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Forwards and backwards movement
        rigid.MovePosition(
                             transform.position + 
                            (transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime) +
                            (transform.right * Input.GetAxis("Horizontal")
                            * speed * Time.deltaTime)
                            );

    }

}
