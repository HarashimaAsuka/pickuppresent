using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkaterController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 5f;
    public float deceleration = 2f;
    public Rigidbody rb;

    private Vector3 currentVelocity;

    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.drag = 0;
        rb.angularDrag = 0;
    }

    void Update(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);

        if(movement.magnitude > 0.1f){
            currentVelocity = movement.normalized * speed;
        }
        else{
            currentVelocity = Vector3.Lerp(currentVelocity,Vector3.zero,deceleration * Time.deltaTime);
        }
    }
}
